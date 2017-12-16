using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Otaku_Time
{
    public partial class EpisodeDownloadObject : UserControl
    {

        string URL = "";
        string fileName = "";
        string episodeName = "";
        WebClient wc;

        public bool IsDownloading = false;

        public EpisodeDownloadObject(string URL, string fileName, string episodeName)
        {
            InitializeComponent();
            this.URL = URL;
            this.episodeName = episodeName;
            this.fileName = fileName + @"\" + episodeName + ".mp4";
            visibleName.Text = fileName + " - " + episodeName;
        }

        public void downloadFile()
        {
            using (wc = new WebClient())
            {
                if (URL == "no")
                {
                    wc.Dispose();
                    this.Dispose();
                    return;
                }
                wc.DownloadFileAsync(new Uri(URL), fileName);
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                IsDownloading = true;
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Cancelled || e.Error != null)
            {
                File.Delete(fileName);
            }
            ((DownloadingEpisodes)this.FindForm()).CheckForNextDownload();
            wc.Dispose();
            this.Dispose();
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            PB.Value = e.ProgressPercentage;
        }

        private void abort_Click(object sender, EventArgs e)
        {
            try
            {
                wc.CancelAsync();
            }
            catch(Exception)
            {

            }
            this.Dispose();
            
        }
    }
}
