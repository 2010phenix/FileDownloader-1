using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDownloader.Core
{
    /// <summary>
    /// Асинхронный downloader
    /// </summary>
    public class FileAsyncDownloader
    {
        /// <summary>
        /// Синхронный downloader <see cref="FileDownLoader"/>
        /// </summary>
        private FileDownloader _syncDownloader = new FileDownloader();


        /// <summary>
        /// Обработчик события окончания скачивания файла
        /// </summary>
        public event Action<byte[]> FileDownloaded;


        /// <summary>
        /// Асинхронный метод скачивания
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Байтовый массив(файл)</returns>
        private async Task<byte[]> DownloadAsync(string url)
        {
            byte[] res = await Task.Run(() =>
                {

                    lock (_syncDownloader)
                    {
                        //Console.WriteLine("Starting the file download ...");

                        return _syncDownloader.Download(url);
                    }
                });

            return res;
        }


        /// <summary>
        /// Асинхронный метод-обертка
        /// </summary>
        /// <param name="url"></param>
        public void Download(string url)
        {           
            Task<byte[]> dwTask = DownloadAsync(url);

            dwTask.ContinueWith(x => FileDownloaded(x.Result));
        }
    }
}
