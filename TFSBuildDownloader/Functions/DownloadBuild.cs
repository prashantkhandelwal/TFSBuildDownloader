using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TFSBuildDownloader.Functions
{
    internal class DownloadBuild
    {
        private string _buildURL = string.Empty;
        private string _output = string.Empty;
        private Int64 BytesReceived = 0;
        internal DownloadBuild(string BuildURL, string OutputPath)
        {
            _buildURL = BuildURL;
            _output = OutputPath;
        }

        public void Download()
        {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);

            client.DownloadFileAsync(new Uri(_buildURL), _output);
        }

        private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.ToString());
            }
            Download();
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            #region Old
            //double incomingBytes = double.Parse(e.BytesReceived.ToString());
            //double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            //double percentageCompleted = double.Parse(e.ProgressPercentage.ToString());
            //double percentageCompleted = incomingBytes/totalBytes * 100;
            #endregion

            BytesReceived += int.Parse(e.BytesReceived.ToString());

            //To see packet download, un-comment the below line
            ///////Console.WriteLine(e.BytesReceived.ToString() + "/" + e.TotalBytesToReceive.ToString());
            
            Console.Write("\r{0}  ", Utils.SizeSuffix(BytesReceived) + " downloaded");

        }
    }
}
