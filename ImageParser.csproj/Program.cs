using System;
using System.IO;

namespace ImageParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var parser = new ImageParser();
            string imageInfoJson;

            using (var file = new FileStream("test8.png", FileMode.Open, FileAccess.Read))
            {
                imageInfoJson = parser.GetImageInfo(file);
            }

            Console.WriteLine(imageInfoJson);
        }
    }
}

/*
 * 
 * using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ImageParser
{


    public class ImageParser : IImageParser
    {
        public struct Image
        {
            public string Height;
            public string Width;
            public string Format;
            public string Size;

            public Image(string height, string width, string format, string size)
            {
                Height = height;
                Width = width;
                Format = format;
                Size = size;
            }
        }
        public ulong fileSize = 0;
        public string extension = "";

        private static string ToUlong(byte[] bytes)
        {
            return Convert.ToString(bytes[0] + bytes[1] * 256 + bytes[2] * 65536 + bytes[3] * 16777216);
        }

        public string ParsePng(byte[] bytes)
        {
            Image pngImage = new Image();
            byte[] data = new byte[24];
            Array.Copy(bytes, data, 24);
            byte[] width = new byte[4];
            Array.Copy(data.Skip(16).Take(4).ToArray(), width, 4);

            byte[] height = new byte[4];
            Array.Copy(data.Skip(20).Take(4).ToArray(), height, 4);
            Array.Reverse(width);
            Array.Reverse(height);

            pngImage.Width = ToUlong(width);
            pngImage.Height = ToUlong(height);
            pngImage.Format = "Png";
            pngImage.Size = Convert.ToString(fileSize);

            return JsonConvert.SerializeObject(pngImage); //, Formatting.Indented);
        }

        public string ParseBmp(byte[] bytes)
        {
            byte[] width = new byte[4];
            byte[] height = new byte[4];
            Array.Copy(bytes.Skip(18).Take(4).ToArray(), width, 4);
            Array.Copy(bytes.Skip(22).Take(4).ToArray(), height, 4);

            Image bmpImage = new Image(ToUlong(height), ToUlong(width), "Bmp", Convert.ToString(fileSize));
            return JsonConvert.SerializeObject(bmpImage); 
        }

        public string ParseGif(byte[] bytes)
        {
            byte[] width = new byte[4];
            byte[] height = new byte[4];
            Array.Copy(bytes.Skip(6).Take(2).ToArray(), width, 2);
            Array.Copy(bytes.Skip(8).Take(2).ToArray(), height, 2);
            Image gifImage = new Image(ToUlong(height), ToUlong(width), "Gif", Convert.ToString(fileSize));
            return JsonConvert.SerializeObject(gifImage);
        }

        public string DetectExtension(byte[] bytes)
        {
            byte[] pngBytes = { 137, 80, 78, 71, 13, 10, 26, 10 };
            byte[] gifBytes = { 47, 49, 46, 38, 39, 61 };

            int isPng = 0,
                isGif = 0;
            for (int i = 0; i < pngBytes.Length; i++)
            {
                if (pngBytes[i] == bytes[i])
                {
                    isPng++;
                }
                if (i < 6)
                {
                    if (Convert.ToInt32(gifBytes[i].ToString(), 16) == bytes[i])
                    {
                        isGif++;
                    }
                }
            }
            if (isPng == 8)
                return "Png";
            if (isGif == 6)
                return "Gif";
            return "Bmp";
        }

        public string GetImageInfo(Stream stream)
        {
            FileStream myFileStream = stream as FileStream;
            MemoryStream myMemoryStream = new MemoryStream();
            stream.CopyTo(myMemoryStream);
            byte[] byttes = myMemoryStream.ToArray();
            fileSize = (ulong)stream.Length;
            extension = DetectExtension(byttes);
            if (extension == "Png")
                return ParsePng(byttes);
            if (extension == "Bmp")
                return ParseBmp(byttes);
            return ParseGif(byttes);
        }
    }


}
}
 */
