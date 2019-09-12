using ringba_test.AppConstants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ringba_test.Helpers
{
   public static class IOHelper
    {
        public static void DownloadFile()
        {
            if (!File.Exists(Constants.FilePath))
            {
                Directory.CreateDirectory(Constants.AppPath);
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile(Constants.FileUri, Constants.FilePath);
            }
        }
    }
}
