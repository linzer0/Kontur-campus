using NUnit.Framework;
using System;
using System.IO;

namespace ImageParser
{
    [TestFixture]
    public class ImageParserTests
    {
        private ImageParser parser;

        [SetUp]
        public void SetUp()
        {
            parser = new ImageParser();
        }
        [Test]
        public void PngTest1()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/image.png";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            Console.Write(x);
            var y = "{\"Height\":292,\"Width\":640,\"Format\":\"Png\",\"Size\":229983}";
            Assert.True(x == y);
        }
        [Test]
        public void PngTest2()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test2.png";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            var y = "{\"Height\":600,\"Width\":600,\"Format\":\"Png\",\"Size\":3974}";
            Assert.True(x == y);

        }
        [Test]
        public void PngTest3()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test4.png";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            var y = "{\"Height\":1080,\"Width\":1920,\"Format\":\"Png\",\"Size\":3124201}";
            Assert.True(x == y);

        }
        [Test]
        public void PngTest4()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test5.png";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            var y = "{\"Height\":1350,\"Width\":1800,\"Format\":\"Png\",\"Size\":5249494}";
            Assert.True(x == y);

        }
        [Test]
        public void PngTest5()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test6.png";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            var y = "{\"Height\":1538,\"Width\":3984,\"Format\":\"Png\",\"Size\":10473459}";
            Assert.True(x == y);

        }
        [Test]
        public void PngTest6()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test7.png";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            var y = "{\"Height\":2271,\"Width\":5891,\"Format\":\"Png\",\"Size\":21141605}";
            Assert.True(x == y);

        }
        [Test]
        public void PngTest7()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test8.png";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            var y = "{\"Height\":2832,\"Width\":7345,\"Format\":\"Png\",\"Size\":32916531}";
            Assert.True(x == y);

        }
        [Test]
        public void PngBigTest()
        {
            string path = "/home/linzero/projects/kontur/2019/ImageParser.csproj/pictures";
            string[] filePaths = Directory.GetFiles(path, "*png",
                                         SearchOption.TopDirectoryOnly);
            foreach(var file in filePaths)
            {
                Stream stream = new FileStream(file, FileMode.Open);
                var x = parser.GetImageInfo(stream);
                Console.WriteLine(x);
            }

        }

        [Test]
        public void BmpTest1()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test2.bmp";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            Console.WriteLine(x);

            var y = "{\"Height\":300,\"Width\":200,\"Format\":\"Bmp\",\"Size\":180056}";
            Assert.True(x == y);
        }
        [Test]
        public void BmpTest2()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test3.bmp";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            Console.WriteLine(x);
            var y = "{\"Height\":720,\"Width\":1280,\"Format\":\"Bmp\",\"Size\":2764856}";
            Assert.True(x == y);
        }

        [Test]
        public void GifTest1()
        {
            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test1.gif";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            Console.WriteLine(x);

            var y = "{\"Height\":217,\"Width\":217,\"Format\":\"Gif\",\"Size\":182792}";
            Assert.True(x == y);
        }
        [Test]
        public void GifTest2()
        {

            string filePath = "/home/linzero/projects/kontur/2019/ImageParser.csproj/test2.gif";
            Stream stream = new FileStream(filePath, FileMode.Open);
            var x = parser.GetImageInfo(stream);
            Console.WriteLine(x);

            var y = "{\"Height\":433,\"Width\":650,\"Format\":\"Gif\",\"Size\":266865}";
            Assert.True(x == y);
        }


    }
}