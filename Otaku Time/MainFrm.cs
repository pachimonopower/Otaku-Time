using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using HtmlAgilityPack;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Otaku_Time
{

    public partial class MainFrm : Form
    {
        public PhantomJSDriver PhantomObject;
        public DownloadingEpisodes DE;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainFrm()
        {
            foreach (Process p in Process.GetProcessesByName("PhantomJS"))
            {
                p.Kill();
            }

            InitializeComponent();
            optionStrip.Renderer = new RemStripBar();
            if (this.DesignMode == false)
            {
                PhantomObject = Statics.PhantomObject();
                DE = DownloadingEpisodes.GetMe();
                DE.Hide();
            }
            VersionTxt.Text += Application.ProductVersion;
            GoThroughDecorate(this);
            ProgramText.BackColor = Statics.GetColor();
            LoadedAnime.AnimeSynopsis.BackColor = Statics.GetColor();
        }

        private void GoThroughDecorate(Control C)
        {
            if (C.BackColor == SystemColors.MenuHighlight)
            {
                Statics.DecorateControl(C);
            }
            foreach (Control Cont in C.Controls)
            {
                GoThroughDecorate(Cont);
            }
        }
        private void MoveThisform(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(e.Clicks == 1)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
                else if(e.Clicks == 2)
                {
                    var SelectedState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
                    this.WindowState = SelectedState;
                }
                
            }
        }
        #region Menu Options
        private void CloseBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaximizeBtnClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        private void MinimizeBtnClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        private List<AnimePane> MainMobileUpdates()
        {
            List<AnimePane> Animes = new List<AnimePane>();

            if (PhantomObject.Title.Contains("KissAnime Mobile") == false)
                PhantomObject.Navigate().GoToUrl($"http://{Statics.MasterURL}/m");
            foreach (var x in PhantomObject.FindElementsByTagName("article"))
            {
                string ImageLocation = x.FindElement(By.TagName("img")).GetAttribute("src");
                string AnimeName = x.FindElement(By.ClassName("post-content")).FindElement(By.TagName("h2")).FindElement(By.TagName("a")).Text;
                string AnimeSeriesURL = x.GetAttribute("alink");
                AnimePane AP = new AnimePane();
                AP.AnimeName = AnimeName;
                AP.AnimeThumbnailURL = ImageLocation;
                AP.AnimeSeriesURL = AnimeSeriesURL;
                Animes.Add(AP);
            }
            return Animes;
        }

        private List<AnimePane> loadAnimeViaMobile(string SearchQuery, int limit)
        {
            List<AnimePane> MobileResults = new List<AnimePane>();
            string EncodedForURLSearchQuery = System.Web.HttpUtility.UrlEncode(SearchQuery);
            PhantomObject.Navigate().GoToUrl($"http://{Statics.MasterURL}/M?key=" + EncodedForURLSearchQuery + "&sort=search");
            foreach (var x in PhantomObject.FindElementsByTagName("article"))
            {
                string ImageLocation = x.FindElement(By.TagName("img")).GetAttribute("src");
                string AnimeName = x.FindElement(By.ClassName("post-content")).FindElement(By.TagName("h2")).FindElement(By.TagName("a")).Text;
                string AnimeSeriesURL = x.GetAttribute("alink");
                AnimePane AP = new AnimePane();
                AP.AnimeName = AnimeName;
                AP.AnimeThumbnailURL = ImageLocation;
                AP.AnimeSeriesURL = AnimeSeriesURL;
                MobileResults.Add(AP);
            }
            return MobileResults;
        }

        public void LoadMainScreen()
        {
            buildLayout(MainMobileUpdates());
        }

        private void buildLayout(List<AnimePane> AnimeList)
        {
            Statics.InvokeIfRequired(MainFrmPanel, MainFrmPanel.SuspendLayout);
            Statics.InvokeIfRequired(MainFrmPanel, () =>
            {
                while(MainFrmPanel.Controls.Count > 0)
                {
                    MainFrmPanel.Controls[0].Dispose();
                }
            });
            GC.Collect(); //clear old bitmap cache, if needed.
            Statics.InvokeIfRequired(MainFrmPanel, MainFrmPanel.Controls.Clear);
            List<Control> ALIst = new List<Control> { };
            Random R = new Random();
            foreach (AnimePane SinglePane in AnimeList)
            {
                AnimeControl AC = new AnimeControl();
                AC.AnimeName.Text = SinglePane.AnimeName.Replace("&","&&");
                if (SinglePane.AnimeThumbnailURL.Contains(Statics.MasterURL))
                {
                    AC.AnimeImage.Image = GetImage(SinglePane.AnimeThumbnailURL);
                }
                else
                {
                    AC.AnimeImage.ImageLocation = SinglePane.AnimeThumbnailURL;
                }
                AC.AnimeURL = SinglePane.AnimeSeriesURL;
                AC.AnimeSynposis = SinglePane.AnimeSeriesSynopsis;
                ALIst.Add(AC);
            }
            Statics.InvokeIfRequired(MainFrmPanel, () => MainFrmPanel.Controls.AddRange(ALIst.ToArray()));
            Statics.InvokeIfRequired(MainFrmPanel, MainFrmPanel.ResumeLayout);
        }

        private Image GetImage(string ImageLocation)
        {
            byte[] data = null;
            using (CustomWebClient WC = new CustomWebClient())
            {
                WC.Headers.Add(System.Net.HttpRequestHeader.UserAgent, "Mozilla/5.0 (iPhone; CPU iPhone OS 10_0_1 like Mac OS X) AppleWebKit/601.1 (KHTML, like Gecko) CriOS/53.0.2785.109 Mobile/14A403 Safari/601.1.46");
                WC.Headers.Add(System.Net.HttpRequestHeader.Cookie, "cf_clearance=" + PhantomObject.Manage().Cookies.GetCookieNamed("cf_clearance").Value);
                data = WC.DownloadData(ImageLocation);
            }
            Bitmap MP = new Bitmap(new System.IO.MemoryStream(data));
            data = null;
            return MP;
        }

        private async void searchAnime(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AnimeSearchQuery.ReadOnly = true;
                await AnimeSearcher();
            }
        }

        private void ShowSearch_Click(object sender, EventArgs e)
        {
            if (AnimeSearchQuery.Visible)
                AnimeSearchQuery.Visible = false;
            else
            {
                AnimeSearchQuery.Visible = true;
                AnimeSearchQuery.Focus();
            }

        }

        public void startLoadingAnimeInformation(AnimeControl AC)
        {
            string AnimeSeriesURL = AC.AnimeURL;
            string AnimeName = AC.AnimeName.Text;
            string AnimeSynopsis = AC.AnimeSynposis;
            string AnimeThumbnailURL = AC.AnimeImage.ImageLocation;
            LoadedAnime.AnimeName.Text = AnimeName;
            LoadedAnime.AnimeSynopsis.Text = AnimeSynopsis;
            LoadedAnime.AnimeImage.Image = AC.AnimeImage.Image;
            LoadedAnime.AnimeURL = $"http://{Statics.MasterURL}" + AnimeSeriesURL;
            LoadedAnime.loadAnimeList(AnimeSeriesURL, true);
            MainFrmPanel.SendToBack();
        }

        private void optionStrip_Resize(object sender, EventArgs e)
        {
            ProgramText.Margin = new Padding(optionStrip.Width / 2 - 40, 1, 0, 2);
        }

        private void ShowDownloads_Click(object sender, EventArgs e)
        {
            DE.Show();
            DE.BringToFront();
        }

        private async Task AnimeSearcher()
        {
            await Task.Run(() =>
            {
                buildLayout(loadAnimeViaMobile(AnimeSearchQuery.Text, 999));
                Statics.InvokeIfRequired(this, () =>
                {
                    UseWaitCursor = false;
                    AnimeSearchQuery.ReadOnly = false;
                    AnimeSearchQuery.Clear();
                    AnimeSearchQuery.Visible = false;
                });
            });
            MainFrmPanel.Refresh();
        }

        private void InfoBtrn_Click(object sender, EventArgs e)
        {
            AboutInfo.BringToFront();
        }

        private void GoHome_Click(object sender, EventArgs e)
        {
            MainFrmPanel.BringToFront();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DE.DownloadCount > 0)
            {
                if (MessageBox.Show("You are currently downloading, are you sure you wish you close down Otaku Time?", "Otaku Time", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            PhantomObject.Dispose();
            Application.Exit();
        }

        private const int cGrip = 32;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}