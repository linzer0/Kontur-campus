using System;
using System.IO;
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
        public string fileSize;
        public string extension = "";

        private static string ToUlong(byte[] bytes)
        {
            return Convert.ToString(bytes[0] + bytes[1] * 256 + bytes[2] * 65536 + bytes[3] * 16777216);
        }

        public string ParsePng(byte[] bytes)
        {
            byte[] data = new byte[24];
            Array.Copy(bytes, data, 24);
            byte[] width = new byte[4];
            width[0] = data[19];
            width[1] = data[18];
            width[2] = data[17];
            width[3] = data[16];

            byte[] height = new byte[4];
            height[0] = data[23];
            height[1] = data[22];
            height[2] = data[21];
            height[3] = data[20];
            Image pngImage = new Image(ToUlong(height), ToUlong(width), "Png", fileSize);
            return JsonConvert.SerializeObject(pngImage);
        }

        public string ParseBmp(byte[] bytes)
        {
            byte[] width = new byte[4];
            byte[] height = new byte[4];
            width[0] = bytes[18];
            width[1] = bytes[19];
            width[2] = bytes[20];
            width[3] = bytes[21];

            height[0] = bytes[22];
            height[1] = bytes[23];
            height[2] = bytes[24];
            height[3] = bytes[25];

            Image bmpImage = new Image(ToUlong(height), ToUlong(width), "Bmp", fileSize);
            return JsonConvert.SerializeObject(bmpImage);
        }

        public string ParseGif(byte[] bytes)
        {
            byte[] width = new byte[4];
            byte[] height = new byte[4];

            width[0] = bytes[6];
            width[1] = bytes[7];
            height[0] = bytes[8];
            height[1] = bytes[9];

            Image gifImage = new Image(ToUlong(height), ToUlong(width), "Gif", fileSize);
            return JsonConvert.SerializeObject(gifImage);
        }

        public string DetectExtension(byte[] bytes)
        {
            byte[] pngBytes = { 137, 80, 78, 71, 13, 10, 26, 10 };
            byte[] gifBytes = { 47, 49, 46, 38, 39, 61 };

            if (pngBytes[0] == bytes[0] && pngBytes[7] == bytes[7])
            {
                extension = "Png";
                return ParsePng(bytes);
            }
            if (Convert.ToInt32(gifBytes[0].ToString(), 16) == bytes[0] && Convert.ToInt32(gifBytes[5].ToString(), 16) == bytes[5])
            { 
                extension = "Gif";
                return ParseGif(bytes);
            }
            extension = "Bmp";
            return ParseBmp(bytes);
        }

        public string GetImageInfo(Stream stream)
        {
            FileStream myFileStream = stream as FileStream;
            MemoryStream myMemoryStream = new MemoryStream();
            stream.CopyTo(myMemoryStream);

            byte[] bytes = myMemoryStream.ToArray();
            fileSize = Convert.ToString(stream.Length);
            return DetectExtension(bytes);
        }
    }
}