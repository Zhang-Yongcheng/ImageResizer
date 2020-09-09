using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            //原始
            imageProcess.Clean(destinationPath);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();
            Console.WriteLine($"原始花費時間: {sw.ElapsedMilliseconds} ms");

            //非同步
            imageProcess.Clean(destinationPath);
            sw.Restart();
            Console.WriteLine("縮放作業開始: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
            await imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            Console.WriteLine("縮放作業結束: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
            sw.Stop();

            Console.WriteLine($"非同步花費時間: {sw.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

    }
}
