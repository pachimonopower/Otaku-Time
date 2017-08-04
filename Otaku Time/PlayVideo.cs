using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Beautiplayer;

namespace Otaku_Time
{
    public partial class PlayVideo : Form
    {
        private string episodeName = "";
        private string episodeURL = "";
        private List<string> EpNames = new List<string> { };

        public BeautiplayerCtrl Player;

        public PlayVideo(string epName, string url)
        {
            try
            {
                InitializeComponent();
                episodeName = epName;
                episodeURL = url;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }

        }

        private void PlayVideo_Load(object sender, EventArgs e)
        {
            Player = new BeautiplayerCtrl();
            Player.Dock = DockStyle.Fill;
            this.Controls.Add(Player);
            this.Text = episodeName;
            Player.playVideo(episodeURL);
            this.BringToFront();
        }

        public bool addToQueue(string epname, string eplink)
        {
            if (EpNames.Contains(epname))
            {
                return false;
            }
            else
            {
                Player.addToQueue(eplink);
                EpNames.Add(epname);
                return true;
            }
        }

        private void PlayVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
           Player.Dispose();
        }

        private void Player_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
        {
            if (EpNames.Count > 0)
            {
                string nextUpAnime = EpNames.FirstOrDefault();
                EpNames.Remove(nextUpAnime);
                this.Text = nextUpAnime;
                Player.NextVideo();
            }
            else
            {
                this.Dispose();
            }
        }

        private void checkToClose()
        {
            Player.playVideo("");
            if (EpNames.Count == 0)
            {
                this.Close();
            }
        }

        private void changeText()
        {
            this.Text = EpNames.FirstOrDefault();
            EpNames.Remove(EpNames.FirstOrDefault());
        }
    }
}
