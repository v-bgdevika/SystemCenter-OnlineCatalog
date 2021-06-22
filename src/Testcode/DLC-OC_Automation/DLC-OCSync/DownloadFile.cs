using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public enum DownloadStatus
    {
        None,
        Success,
        Failure
    }

    public class DownloadFile
    {
        public string LocalPath { get; set; }
        public DownloadStatus Status { get; private set; }
        private string fileName;
        private string randomFile;
        private string randomFilePath;

        /// <summary>
        /// Constructor which takes url
        /// </summary>
        /// <param name="url">string</param>
        public DownloadFile(string url)
        {
            try
            {
                WebClient client = new WebClient();
                this.fileName = Path.GetFileName(url);
                this.randomFile = Path.GetRandomFileName();
                this.randomFilePath = Path.GetTempPath() + this.randomFile;

                Directory.CreateDirectory(this.randomFilePath);
                this.LocalPath = this.randomFilePath + "\\" + this.fileName;
                client.DownloadFile(url, this.LocalPath);
                this.Status = DownloadStatus.Success;
            }
            catch(Exception e)
            {
                Common.Exception("Download failed " + url);
                this.Status = DownloadStatus.Failure;
            }
        }

        /// <summary>
        /// Destructor to delete file
        /// </summary>
        ~DownloadFile()
        {
            try
            {
                File.Delete(this.LocalPath);
                Directory.Delete(this.randomFilePath);
            }
            catch(Exception e)
            {
                Common.Exception("Unable to delete " + this.LocalPath);
            }
        }
    }
}
