using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSearcher_Windows
{

    public enum SIUnits
    {
        B,
        KB,
        MB,
        GB,
        TB,
        PB
    }
    public partial class ImageSelector : Form
    {
        private HashSet<String> imageShas;
        private HashSet<String> uniqueFilePaths;
        private List<Tuple<string,bool, long>> finalImages;
        private List<Tuple<string,bool, long>> finalVideos;
        private long ImageSize = 0;
        private long VideoSize = 0;
        private int copiedImages = 0;
        private int copiedVideos = 0;
        private long copiedImageSize = 0;
        private long copiedVideoSize = 0;
        private int duplicateCount;
        private String savePath;
        private long AvailableFreeSpace;
        ConcurrentQueue<Tuple<int, long>> imageMessageQueue;// = new ConcurrentQueue<Tuple<int, long>>();
        ConcurrentQueue<Tuple<int, long>> videoMessageQueue;
        public ImageSelector()
        {
            InitializeComponent();
            imageShas = new HashSet<String>();
            finalImages = new List<Tuple<string,bool, long>>();
            finalVideos = new List<Tuple<string,bool, long>>();
            uniqueFilePaths = new HashSet<string>();
        }

        delegate void SetAddFilesCallback(List<Tuple<string, bool, long>> files);

        delegate void SetImageLabelCallback(int copiedImages, int totalImages, long copiedImageSize, long totalImageSize);
        delegate void SetVideoLabelCallback(int copiedVideos, int totalVideos, long copiedVideoSize, long totalVideoSize);


        public void Reset()
        {
            this.imageShas = new HashSet<String>();
            this.finalImages = new List<Tuple<string,bool, long>>();
            this.finalVideos = new List<Tuple<string, bool, long>>();
            this.uniqueFilePaths = new HashSet<string>();
            this.duplicateCount = 0;
            this.savePath = null;
        }

        public void addHashSet(HashSet<String> hashSet) 
        {
            foreach(String hash in hashSet)
            {
                Console.WriteLine(hash);
            }
            this.imageShas.UnionWith(hashSet);
        }

        public void SetSavePath(String savePath)
        {
            this.savePath = savePath;
        }

        public void SetAvailableFreeSpace(long space)
        {
            this.AvailableFreeSpace = space;
            if (this.AvailableFreeSpace <= this.ImageSize)
            {
                this.ImageSizeTooLargeLabel.Enabled = true;
                this.ImageSizeTooLargeLabel.Visible = true;
                this.CopyImagesBtn.Enabled = false;
            }
            if (this.AvailableFreeSpace <= (this.VideoSize))
            {
                if (this.ImageSizeTooLargeLabel.Enabled)
                {
                    this.VideoSizeTooLargeLabel.Location = new Point(this.VideoSizeTooLargeLabel.Location.X, (this.VideoSizeTooLargeLabel.Location.Y + this.ImageSizeTooLargeLabel.Size.Height + 1));
                }
                this.VideoSizeTooLargeLabel.Enabled = true;
                this.VideoSizeTooLargeLabel.Visible = true;
                this.CopyVideosBtn.Enabled = false;

            }
            if (this.AvailableFreeSpace <= (this.ImageSize + this.VideoSize))
            {
                if (this.ImageSizeTooLargeLabel.Enabled)
                {
                    this.CombinedTooLargeLabel.Location = new Point(this.CombinedTooLargeLabel.Location.X, (this.CombinedTooLargeLabel.Location.Y + this.ImageSizeTooLargeLabel.Size.Height + 1));
                }
                if (this.VideoSizeTooLargeLabel.Enabled)
                {
                    this.CombinedTooLargeLabel.Location = new Point (this.CombinedTooLargeLabel.Location.X, (this.CombinedTooLargeLabel.Location.Y + this.VideoSizeTooLargeLabel.Size.Height+1));
                }
                this.CombinedTooLargeLabel.Enabled = true;
                this.CombinedTooLargeLabel.Visible = true;
                this.CopyBtn.Enabled = false;

            }
        }
        public void AddFiles(List<Tuple<string, bool, long>> files)
        {
            if (this.totalImagesLabel.InvokeRequired)
            {
                SetAddFilesCallback d = new SetAddFilesCallback(AddFiles);
                this.Invoke(d, new object[] { files });
            }
            else
            {
                //lock (this.finalImages)
                //{
                    //IList<String> newFiles = new List<String>();
                foreach (Tuple<string, bool, long> imagePath in files)
                {
                    if (!imagePath.Item2)
                    {
                        /*lock (this.uniqueFilePaths)
                        {
                            if (this.uniqueFilePaths.Add(imagePath.Item1))
                            {*/
                                this.addImage(imagePath);
                       /*     }
                        }*/
                    }
                    else
                    {
                        lock (this.finalVideos)
                        {
                            /*lock (this.uniqueFilePaths)
                            {
                                if (this.uniqueFilePaths.Add(imagePath.Item1))
                                {*/
                                    this.finalVideos.Add(imagePath);
                                    this.VideoSize += imagePath.Item3;
                                /*}
                            }*/
                        }
                    }
                    
                }
                    Console.WriteLine("Adding files to list");
                //imageList.Items.AddRange(newFiles.ToArray());
                //newFiles = null;
                lock (this.finalImages)
                {
                    this.setImageLabel(0, this.finalImages.Count(), 0, this.ImageSize);
                    this.totalImagesLabel.Text = this.finalImages.Count.ToString();
                }
                lock (this.finalVideos) {
                    this.totalVideosLabel.Text = this.finalVideos.Count.ToString();
                    this.setVideoLabel(0, this.finalVideos.Count(), 0, this.VideoSize);
                }
                this.duplicateCountLabel.Text = this.duplicateCount.ToString();
                //}
            }
        }

        private void addImage(Tuple<string, bool, long> imagePath)
        {
            try
            {
                Console.WriteLine("Current File: " + imagePath.Item1);
                using (FileStream fileStream = new FileStream((string)imagePath.Item1, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (Image image = Image.FromStream(fileStream))
                        {
                            byte[] imageBytes = ImageToByteArray(image);
                            if (imageBytes == null)
                            {
                                Console.WriteLine("Image Bytes were null");
                                return;
                            }
                            byte[] hash;
                            try
                            {
                                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                                {
                                    sha256.TransformFinalBlock(imageBytes, 0, imageBytes.Length);
                                    hash = sha256.Hash;
                                    //Console.WriteLine(Encoding.UTF8.GetString(hash));
                                    bool testHashBool = this.imageShas.Add(Encoding.UTF8.GetString(hash));
                                    if (!testHashBool)
                                    {
                                        Console.WriteLine("Image was duplicate!");
                                        this.duplicateCount++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Image succesffully shad and added to hashset");
                                        lock (this.finalImages)
                                        {
                                            this.finalImages.Add(imagePath);
                                            this.ImageSize += imagePath.Item3;

                                        }

                                    }
                                }
                            }
                            catch (System.Security.Cryptography.CryptographicException ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }

                            imageBytes = null;
                        }
                    }
                    catch (System.OutOfMemoryException ex)
                    {
                        //
                        return;
                    }

                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch(System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            return;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    if (imageIn.RawFormat != null)
                    {
                        imageIn.Save(ms, imageIn.RawFormat);
                        return ms.ToArray();
                    }
                    else
                    {
                        Console.WriteLine("Image Format was null");
                        return null;
                    }
                }
                catch(System.Runtime.InteropServices.ExternalException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        private void removedDuplicatesLabel_Click(object sender, EventArgs e)
        {

        }

        private static void CopyFiles(object state)
        {
            object[] array = state as object[];
            List<Tuple<string, bool, long>> files = (List<Tuple<string, bool, long>>)array[0];
            String savePath = (String)array[1];
            AutoResetEvent are = (AutoResetEvent)array[2];
            ImageSelector imageSelector = (ImageSelector)array[3];
            //int copiedCount = 0;
            //long copiedSize = 0;
            foreach (Tuple<string, bool, long> file in files)
            {
                try
                {
                    File.Copy(file.Item1, Path.Combine(savePath, Path.GetFileName(file.Item1)));
                    if (!file.Item2)
                    {
                        imageSelector.imageMessageQueue.Enqueue(new Tuple<int, long>(1, file.Item3));
                    }
                    else
                    {
                        imageSelector.videoMessageQueue.Enqueue(new Tuple<int, long>(1, file.Item3));
                    }
                    //copiedCount++;
                    //copiedSize += file.Item3;
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine("Renaming " + file.Item1);
                    var uniqueId = System.Text.RegularExpressions.Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");

                    var filename = Path.GetFileNameWithoutExtension(file.Item1);
                    var extension = Path.GetExtension(file.Item1);
                    try
                    {
                        File.Copy(file.Item1, Path.Combine(savePath, filename + '_' + uniqueId + extension));
                        if (!file.Item2)
                        {
                            imageSelector.imageMessageQueue.Enqueue(new Tuple<int, long>(1, file.Item3));
                        }
                        else
                        {
                            imageSelector.videoMessageQueue.Enqueue(new Tuple<int, long>(1, file.Item3));
                        }
                        //copiedCount++;
                        //copiedSize += file.Item3;

                    }
                    catch (System.UnauthorizedAccessException ex2)
                    {
                        continue;
                    }
                    catch(System.IO.PathTooLongException ex2)
                    {
                        continue;
                    }
                    catch(System.IO.IOException ex3)
                    {
                        continue;
                    }
                }
                catch(System.UnauthorizedAccessException ex)
                {
                    continue;
                }
            }
            //queue.Enqueue(new Tuple<int, long>(copiedCount, copiedSize));
            are.Set();
        }

        private Tuple<string, string, string> setSizeLabels(long val1, long val2)
        {
            int count = 0;
            while(val2 > 1000)
            {
                val2 /= 1000;
                count += 1;
            }
            Console.WriteLine("Val1 is: " + val1.ToString());
            val1 /= (long)Math.Pow(1000, count);
            Console.WriteLine("Val1 is now: " + val1.ToString());
            string SI = ((SIUnits)count).ToString();
            return new Tuple<string, string, string>(val1.ToString(), val2.ToString(), SI);
        }

        private void setImageLabel(int copiedImages, int totalImages, long copiedImageSize, long imageSize)
        {
            this.copiedImagesLabel.Text = copiedImages.ToString();
            this.totalImagesLabel.Text = totalImages.ToString();
            Tuple<string, string, string> setSize = setSizeLabels(copiedImageSize, imageSize);
            this.copiedImageSizeLabel.Text = setSize.Item1;
            this.totalImageSizeLabel.Text = setSize.Item2;
            this.siImageSizeLabel.Text = setSize.Item3;
            this.copiedImagesLabel.Update();
            this.totalImagesLabel.Update();
            this.copiedImageSizeLabel.Update();
            this.totalImageSizeLabel.Update();
            this.siImageSizeLabel.Update();
        }

        private void setVideoLabel(int copiedVideos, int totalVideos, long copiedVideoSize, long VideoSize)
        {
            this.copiedVideosLabel.Text = copiedVideos.ToString();
            this.totalVideosLabel.Text = totalVideos.ToString();
            Tuple<string, string, string> setSize = setSizeLabels(copiedVideoSize, VideoSize);
            Console.WriteLine("Updating copiedVideoSizeLabel to: " + setSize.Item1);
            this.copiedVideoSizeLabel.Text = setSize.Item1;
            this.totalVideoSizeLabel.Text = setSize.Item2;
            this.siVideoSizeLabel.Text = setSize.Item3;
            this.copiedVideosLabel.Update();
            this.totalVideosLabel.Update();
            this.copiedVideoSizeLabel.Update();
            this.totalVideoSizeLabel.Update();
            this.siVideoSizeLabel.Update();
        }

        private void updateQueue()
        {
            SetImageLabelCallback setImageLabelCallback = new SetImageLabelCallback(setImageLabel);
            SetVideoLabelCallback setVideoLabelCallback = new SetVideoLabelCallback(setVideoLabel);
            Tuple<int, long> imageValues = null;
            Tuple<int, long> videoValues = null;
            while (!imageMessageQueue.IsEmpty || !videoMessageQueue.IsEmpty)
            {
                if (!imageMessageQueue.IsEmpty)
                {
                    imageMessageQueue.TryDequeue(out imageValues);
                    if (imageValues == null)
                    {
                        ;
                    }
                    else
                    {
                        Console.WriteLine("Trying to change image label, increasing size by: "+ imageValues.Item2);
                        this.copiedImages += imageValues.Item1;
                        this.copiedImageSize += imageValues.Item2;
                    }
                    //this.Invoke(setImageLabelCallback, new object[] { this.copiedImages, this.finalImages.Count(), this.copiedImageSize, this.ImageSize });
                    Console.WriteLine("Updating images to: " + copiedImages.ToString() + " with size: " + copiedImageSize.ToString());
                    this.setImageLabel(this.copiedImages, this.finalImages.Count(), this.copiedImageSize, this.ImageSize);
                    imageValues = null;
                }
                //}
                //while (!this.videoMessageQueue.IsEmpty)
                //{
                if (!videoMessageQueue.IsEmpty)
                {
                    videoMessageQueue.TryDequeue(out videoValues);
                    if (videoValues == null)
                    {
                        ;
                    }
                    else
                    {
                        Console.WriteLine("Trying to change video label, increasing size by: " + videoValues.Item2);
                        this.copiedVideos += videoValues.Item1;
                        this.copiedVideoSize += videoValues.Item2;
                    }
                    //this.Invoke(setVideoLabelCallback, new object[] { this.copiedVideos, this.finalVideos.Count(), this.copiedVideoSize, this.VideoSize });
                    Console.WriteLine("Updating videos to: " + copiedVideos.ToString() + " with size: " + copiedVideoSize.ToString());

                    this.setVideoLabel(this.copiedVideos, this.finalVideos.Count(), this.copiedVideoSize, this.VideoSize);
                    videoValues = null;
                }
            }
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("In button Click");
            Button button = (Button)sender;
            bool checkImages = false;
            bool checkVideos = false;
            Console.WriteLine(button.Name);
            if (button.Name.Contains("CopyImagesBtn"))
            {
                checkImages = true;
            }
            if (button.Name.Contains("CopyVideosBtn"))
            {
                checkVideos = true;
            }
            if (button.Name.Contains("CopyBtn"))
            {
                checkImages = true;
                checkVideos = true;
            }
            var list = new List<List<Tuple<string, bool, long>>>();
            int cores = Environment.ProcessorCount;
            int NumPerCore = (int)(finalImages.Count() / cores);
            int NumVideosPerCore = (int)(finalVideos.Count() / cores);
            int currentCount = 0;
            int currentDir = 1;

            this.imageMessageQueue = new ConcurrentQueue<Tuple<int, long>>();
            this.videoMessageQueue = new ConcurrentQueue<Tuple<int, long>>();

            int threads_running = 0;
            IList<WaitHandle> allQueued = new List<WaitHandle>();
            if (finalImages.Count() > 0 && checkImages)
            {
                if (this.ImageSize > this.AvailableFreeSpace)
                {
                    Console.WriteLine("Copying too many images");
                }
                for (int i = 0; i < finalImages.Count(); i += NumPerCore)
                {
                    list.Add(finalImages.GetRange(i, Math.Min(NumPerCore, finalImages.Count() - i)));
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    allQueued.Add(new AutoResetEvent(false));
                    string finalPath = savePath + "\\images\\" + currentDir.ToString();
                    if (!Directory.Exists(finalPath))
                    {
                        Directory.CreateDirectory(finalPath);
                    }
                    ThreadPool.QueueUserWorkItem(CopyFiles, new object[] { list[i], finalPath, allQueued.Last(), this });
                    threads_running++;
                    currentCount += list[i].Count();
                    if (currentCount > 1000)
                    {
                        currentDir += 1;
                        currentCount = 0;
                    }
                }
                int current_queue_item = 0;
                while (threads_running > 0)
                {
                    current_queue_item = 0;
                    while (allQueued.Count > 0 && current_queue_item < allQueued.Count)
                    {
                        WaitHandle current = allQueued[current_queue_item];
                        if (current.WaitOne(1000))
                        {
                            threads_running--;
                            allQueued.Remove(current);
                        }
                        current_queue_item++;
                        this.updateQueue();
                    }
                }

                allQueued.Clear();
                list.Clear();
            }
            if (finalVideos.Count() > 0 && checkVideos)
            {
                if(this.VideoSize > this.AvailableFreeSpace)
                {
                    Console.WriteLine("Copying too many videos");
                }
                currentDir = 1;
                currentCount = 0;
                for (int i = 0; i < finalVideos.Count(); i+= NumVideosPerCore)
                {
                    list.Add(finalVideos.GetRange(i, Math.Min(NumVideosPerCore, finalVideos.Count() - i)));
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    allQueued.Add(new AutoResetEvent(false));
                    string finalPath = savePath + "\\videos\\" + currentDir.ToString();
                    if (!Directory.Exists(finalPath))
                    {
                        Directory.CreateDirectory(finalPath);
                    }
                    ThreadPool.QueueUserWorkItem(CopyFiles, new object[] { list[i], finalPath, allQueued.Last(), this });
                    threads_running++;
                    currentCount += list[i].Count();
                    if (currentCount > 10)
                    {
                        currentDir += 1;
                        currentCount = 0;
                    }

                }
                int current_queue_item = 0;
                while (threads_running > 0)
                {
                    current_queue_item = 0;
                    while (allQueued.Count > 0 && current_queue_item < allQueued.Count)
                    {
                        WaitHandle current = allQueued[current_queue_item];
                        if (current.WaitOne(1000))
                        {
                            threads_running--;
                            allQueued.Remove(current);
                        }
                        current_queue_item++;
                        this.updateQueue();
                    }
                }
                this.updateQueue();

                allQueued.Clear();
                list.Clear();

                //queueWatcher.Abort();

            }
            bool success = false;
            while (!success)
            {
                try
                {
                    File.Delete(this.savePath + "hashList.txt");
                    using (StreamWriter sw = File.AppendText(this.savePath + "hashList.txt"))
                    {
                        foreach (String hash in imageShas)
                        {
                            sw.WriteLine(hash);
                        }
                        success = true;
                    }
                }
                catch (System.IO.IOException)
                {
                    continue;
                }
            }
            var formPopup = new FinishedPopup();
            formPopup.ShowDialog();
            this.Close();
        }

        private void totalImagesLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void totalVideosLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
