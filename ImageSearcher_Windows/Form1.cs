using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.IO;
using System.Security;

namespace ImageSearcher_Windows
{
    public partial class Form1 : Form
    {
        static String[] png_extensions = { ".PNG", ".png" };
        static String[] jpeg_extensions = { ".JPEG", ".jpeg", ".jpg", ".JPG", ".JPE", ".jpe" };
        static String[] tif_extensions = { ".TIF", ".tif", ".TIFF", ".tiff" };
        static String[] raw_extensions = { ".RAW", ".raw" };
        static String[] bmp_extensions = { ".BMP", ".bmp" };
        static String[] svg_extensions = { ".SVG", ".svg" };
        static String[] mp4_extensions = { ".MP4", ".mp4" };
        static String[] mpeg_extensions = { ".MPEG", ".mpeg", ".MPG", ".mpg" };
        static String[] wmv_extensions = { ".WMV", ".wmv" };
        static String[] avi_extensions = { ".AVI", ".avi" };
        static String[] mov_extensions = { ".MOV", ".mov" };
        static String[] CaseList = { "Images", "Videos" };
        static String[] ImageCaseList = {".PNG",".JPEG", ".TIF", ".RAW", ".BMP", ".SVG"};
        static String[] VideoCaseList = { ".MP4", ".MPEG", ".WMV", ".AVI", ".MOV" };
        static Dictionary<String, String> ImageExtensionConversions = new Dictionary<String, String>();
        static Dictionary<String, String> VideoExtensionConversions = new Dictionary<String, String>();
        static Dictionary<String, String[]> ImageExtensions = new Dictionary<String, String[]>();
        static Dictionary<String, String[]> VideoExtensions = new Dictionary<String, String[]>();

        ImageSelector image2 = new ImageSelector();
        private DriveInfo[] drives;
        private DriveInfo selectedDrive = null;
        private String savePath = null;

        public static void AddExtensions(ref String[] arr, ref Dictionary<String, String> extensionConversions, ref Dictionary<String, String[]> extensions)
        {
            foreach(String ext in arr)
            {
                extensionConversions.Add(ext, arr[0]);
            }
            extensions.Add(arr[0], arr);
        }

        public static void InitializeExtensions()
        {
            AddExtensions(ref png_extensions, ref ImageExtensionConversions, ref ImageExtensions);
            AddExtensions(ref jpeg_extensions, ref ImageExtensionConversions, ref ImageExtensions);
            AddExtensions(ref tif_extensions, ref ImageExtensionConversions, ref ImageExtensions);
            AddExtensions(ref svg_extensions, ref ImageExtensionConversions, ref ImageExtensions);
            AddExtensions(ref bmp_extensions, ref ImageExtensionConversions, ref ImageExtensions);
            AddExtensions(ref raw_extensions, ref ImageExtensionConversions, ref ImageExtensions);
            AddExtensions(ref mp4_extensions, ref VideoExtensionConversions, ref VideoExtensions);
            AddExtensions(ref mpeg_extensions, ref VideoExtensionConversions, ref VideoExtensions);
            AddExtensions(ref wmv_extensions, ref VideoExtensionConversions, ref VideoExtensions);
            AddExtensions(ref avi_extensions, ref VideoExtensionConversions, ref VideoExtensions);
            AddExtensions(ref mov_extensions, ref VideoExtensionConversions, ref VideoExtensions);

        }

        public Form1()
        {
            InitializeComponent();
            InitializeExtensions();
            //Console.SetOut(TextWriter.Null);
            drives = DriveInfo.GetDrives();
            foreach(DriveInfo drive in drives)
            {
                if(drive.DriveType == DriveType.Removable)
                {
                    this.selectedDrive = drive;
                    this.savePath = this.selectedDrive.Name + "Backup\\";
                    break;
                }
            }
            if(selectedDrive == null)
            {
                this.savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Backup\\";
            }
             
            this.selectedFolderText.Text = this.savePath;
            this.selectSaveLocationDialog.SelectedPath = this.savePath;


        }
        private void chkListFormats_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkDirectoryExists()
        {
            if (!Directory.Exists(this.savePath))
            {
                Directory.CreateDirectory(this.savePath);
            }
        }

        private HashSet<String> getExistingHashes()
        {
            String filePath = this.savePath + "hashList.txt";
            if (File.Exists(filePath))
            {
                var hashFile = File.ReadAllLines(filePath, System.Text.Encoding.UTF8);
                foreach(var line in hashFile)
                {
                    Console.WriteLine(line);
                }
                var hashSet = new HashSet<String>(hashFile);
                return hashSet;
            }
            return null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            checkDirectoryExists();
            image2.Reset();
            HashSet<String> existingHashes = getExistingHashes();
            if(existingHashes != null)
            {
                image2.addHashSet(existingHashes);
            }
            image2.SetSavePath(this.savePath);
            Queue<string> formats_to_search = new Queue<string>();
            Cformats cformats = new Cformats();
            if(chkListFormats.CheckedItems.Count != 0)
            {
                for(int x =0; x < chkListFormats.CheckedItems.Count; x++)
                {
                    switch (chkListFormats.CheckedItems[x].ToString())
                    {
                        case "Images":
                            foreach(String ext in ImageCaseList)
                            {
                                formats_to_search.Enqueue(ext);
                            }
                            continue;
                        case "Videos":
                            foreach(String ext in VideoCaseList)
                            {
                                formats_to_search.Enqueue(ext);
                            }
                            continue;
                    }
                }
                int cores = Environment.ProcessorCount;
                IList<WaitHandle> allQueued = new List<WaitHandle>();
                while (formats_to_search.Count > 0)
                {
                            string current = formats_to_search.Dequeue();
                            foreach (DriveInfo drive in this.drives)
                            {
                                allQueued.Add(new AutoResetEvent(false));
                                ThreadPool.QueueUserWorkItem(SearchProcess, new object[] { current, drive.Name, allQueued.Last() });
                            }
                }
                foreach(WaitHandle wh in allQueued)
                {
                    wh.WaitOne();
                }
                allQueued.Clear();
                image2.SetAvailableFreeSpace(new DriveInfo(Path.GetPathRoot(this.savePath)).AvailableFreeSpace);
                image2.ShowDialog();
            }
        }

        public void SearchProcess(object state)
        {
            object[] array = state as object[];
            string current = Convert.ToString(array[0]);
            string drive = Convert.ToString(array[1]);
            AutoResetEvent are = (AutoResetEvent)array[2];
            List<Tuple<string, bool, long>> files = new List<Tuple<string,bool, long>>();
            //string path = "C:\\Users\\";
            string path = drive;
            AddFiles(this.savePath, path, files, current);
            image2.AddFiles(files);
            are.Set();
        }

        public static String ConvertExtension(String extension)
        {
            if (ImageExtensionConversions.ContainsKey(extension))
            {
                return ImageExtensionConversions[extension];
            }
            if (VideoExtensionConversions.ContainsKey(extension))
            {
                return VideoExtensionConversions[extension];
            }
            return null;
        }

        public static String GetExtension(String file)
        {
            String extension = Path.GetExtension(file);
            String finalExtension = ConvertExtension(extension);
            return finalExtension;
        }

        public static void AddFiles(string savePath, string path, List<Tuple<string, bool, long>> files, string current)
        {
            if (!path.EndsWith("\\") && savePath.EndsWith("\\")){
                path += "\\";
            }
            if (path == savePath)
            {
                Console.WriteLine("Skipping same path");
                return;
            }
            IList<string> ignore_list = new List<string>() {
                "$Recycle.Bin",
                "$RECYCLE.BIN"
/*                    "AppData",
                    "Microsoft",
                    "Windows",
                    "Program Files",
                    "Program Files (x86)",
                    "source",
                    "OneDrive",
                    "onedrive",*/
            };
            if (ignore_list.Any(path.Contains))
            {
                return;
            }
            if (ImageExtensions.ContainsKey(current))
            {
                getImageFiles(path, current, ref files);
            }
            else if (VideoExtensions.ContainsKey(current))
            {
                getVideoFiles(path, current, ref files);
            }
            try
            {
                Directory.GetDirectories(path).ToList().ForEach(s => AddFiles(savePath, s, files, current));
            }
            catch (System.UnauthorizedAccessException)
            {
                return;
            }
            
        }

        private static HashSet<string> findFilesMatchingExtension(string path, string current, ref Dictionary<string, string[]> extensions)
        {
            HashSet<string> found_files = new HashSet<string>();
            try
            {
                foreach (string ext in extensions[current])
                {
                    var fileNames = Directory.EnumerateFiles(path, "*" + ext, SearchOption.TopDirectoryOnly);//.ToList().ForEach(s => found_files.Add(s));
                    foreach (string currentFile in fileNames)
                    {
                        found_files.Add(currentFile);
                    }
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                return null;
            }
            return found_files;
        }

        private static void getImageFiles(String path, String current, ref List<Tuple<string, bool, long>> files)
        {

            HashSet<String> found_files = findFilesMatchingExtension(path, current, ref ImageExtensions);
            if (found_files == null) return;
            foreach (string file in found_files)
            {
                string extension = GetExtension(file);
                if (extension == null || extension != current)
                {
                    continue;
                }

                try
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        try
                        {
                            using (var img = Image.FromStream(fs, false, false))
                            {
                                if (img.Width < 540 || img.Height < 540)
                                {
                                    continue;
                                }
                                FileInfo fi = new FileInfo(file);
                                long size = (long)fi.Length;
                                //long size = 0;
                                files.Add(new Tuple<string, bool, long>(file, false, size));
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            continue;
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    continue;
                }
                catch (SecurityException ex)
                {
                    continue;
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    continue;
                }
                catch(System.IO.PathTooLongException ex)
                {
                    continue;
                }
            }
        }

        private static void getVideoFiles(String path, String current, ref List<Tuple<String, bool, long>> files)
        {
            HashSet<String> found_files = findFilesMatchingExtension(path, current, ref VideoExtensions);
            if (found_files == null) return;
            foreach (string file in found_files)
            {
                string extension = GetExtension(file);
                if (extension == null || extension != current)
                {
                    continue;
                }
                try
                {
                    FileInfo fi = new FileInfo(file);
                    long size = (long)fi.Length;
                    files.Add(new Tuple<string, bool, long>(file, true, size));
                }
                catch (ArgumentException ex)
                {
                    continue;
                }
                catch (SecurityException ex)
                {
                    continue;
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    continue;
                }
                catch(System.IO.PathTooLongException ex)
                {
                    continue;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.selectSaveLocationDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.savePath = this.selectSaveLocationDialog.SelectedPath;
                this.selectedFolderText.Text = this.savePath + "\\";
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
