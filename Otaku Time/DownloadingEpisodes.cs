using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Otaku_Time
{
    public partial class DownloadingEpisodes : Form
    {
        private static DownloadingEpisodes MyObject;

        public int CurrentlyDownloading = 0;
        public int MaxDownloading = 0;

        private DownloadingEpisodes()
        {
            InitializeComponent();
            DecoratorClass.GoThroughDecorate(this);
        }

        public int DownloadCount
        {
            get
            {
                return downloaditems.Controls.Count;
            }
        }

        public static DownloadingEpisodes GetMe()
        {
            if (MyObject == null)
            {
                MyObject = new DownloadingEpisodes();
            }
            return MyObject;
        }

        public void addDownload(string URL, string episodeName, string path)
        {
            EpisodeDownloadObject EDO = new EpisodeDownloadObject(URL, path, episodeName);
            if (MaxDownloading == 0 || CurrentlyDownloading != MaxDownloading)
            {
                if(this.Visible == false)
                {
                    this.Show();
                    this.BringToFront();
                }
                EDO.downloadFile();
                CurrentlyDownloading++;
            }
            EDO.Dock = DockStyle.Top;
            EDO.Width = downloaditems.Width - SystemInformation.VerticalScrollBarWidth - 2;
            downloaditems.Controls.Add(EDO);
        }

        private void DownloadingEpisodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;

        }

        public void CheckForNextDownload()
        {
            CurrentlyDownloading--;
            EpisodeDownloadObject NextInQueue = downloaditems.Controls.Cast<EpisodeDownloadObject>().Select(x => x).Where(x => x.IsDownloading == false).FirstOrDefault();
            if(NextInQueue != null)
            {
                NextInQueue.downloadFile();
                CurrentlyDownloading++;
            }
        }
    }
}
