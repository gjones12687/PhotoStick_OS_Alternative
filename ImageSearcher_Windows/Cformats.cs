using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearcher_Windows
{
    class Cformats
    {
        string[] png_formats = { "png", "PNG" };
        string[] jpeg_formats = { "jpeg", "jpg", "JPG", "JPEG" };
        string[] tiff_formats = { "tiff", "tif", "TIFF", "TIF" };
        string[] RAW_formats = { "raw", "RAW" };
        string[] mp4_formats = { "mp4", "MP4" };
        string[] mpeg_formats = { "mpeg", "MPEG", "mpg", "MPG" };
        string[] avi_formats = { "avi", "AVI" };

        public string[] Png_formats { get => png_formats; set => png_formats = value; }
        public string[] Jpeg_formats { get => jpeg_formats; set => jpeg_formats = value; }
        public string[] Tiff_formats { get => tiff_formats; set => tiff_formats = value; }
        public string[] RAW_formats1 { get => RAW_formats; set => RAW_formats = value; }
        public string[] Mp4_formats { get => mp4_formats; set => mp4_formats = value; }
        public string[] Mpeg_formats { get => mpeg_formats; set => mpeg_formats = value; }
        public string[] Avi_formats { get => avi_formats; set => avi_formats = value; }
    }
}
