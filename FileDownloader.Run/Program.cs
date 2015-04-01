using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileDownloader.Run
{
    class Program
    {

        private static Core.FileAsyncDownloader fileDownLoader;
              
        static Program()
        {
            fileDownLoader = new Core.FileAsyncDownloader();
            fileDownLoader.FileDownloaded += DisplayFile;
        }

        static void DisplayFile(byte[] obj)
        {
            Console.WriteLine("File downloaded:{0}", string.Join(", ", obj));
        }



        /// <summary>
        /// Тестовый запуск для 2-х клиентов
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            fileDownLoader.Download(@"http://www.google.com/fileA.txt");

            Thread.Sleep(1000);

            Console.WriteLine("Doing other work ...");


            fileDownLoader.Download("http://www.yandex.ru/fileB.txt");

            fileDownLoader.Download("http://www.yandex.ru/fileC.txt");

            Thread.Sleep(1000);

            Console.WriteLine("Doing other work ...");
            

            Console.ReadLine();
        }



    }
}
