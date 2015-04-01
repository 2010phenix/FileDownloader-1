using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileDownloader.Core
{
    public class FileDownloader
    {
        public byte[] Download(string url)
        {
            Thread.Sleep(5000);

            return new byte[] { 1, 2, 3, 4 };
        }
    } 
}
