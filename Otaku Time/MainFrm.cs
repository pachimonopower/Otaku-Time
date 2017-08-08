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

        #region Win API Stuff
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private const int cGrip = 32;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
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
        private void MoveThisform(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
                else if (e.Clicks == 2)
                {
                    var SelectedState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
                    this.WindowState = SelectedState;
                }

            }
        }
        #endregion

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
                PhantomObject = WebDriverClass.GetPhantomJSInstance();
                DE = DownloadingEpisodes.GetMe();
                DE.Hide();
            }
            VersionTxt.Text += Application.ProductVersion;
            DecoratorClass.GoThroughDecorate(this);
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
        private List<AnimeInfoClass> MainMobileUpdates()
        {
            List<AnimeInfoClass> Animes = new List<AnimeInfoClass>();

            if (PhantomObject.Title.Contains("KissAnime Mobile") == false)
                PhantomObject.Navigate().GoToUrl($"http://{VariablesClass.MasterURL}/m");
            foreach (var x in PhantomObject.FindElementsByTagName("article"))
            {
                string ImageLocation = x.FindElement(By.TagName("img")).GetAttribute("src");
                string AnimeName = x.FindElement(By.ClassName("post-content")).FindElement(By.TagName("h2")).FindElement(By.TagName("a")).Text;
                string AnimeSeriesURL = x.GetAttribute("alink");
                AnimeInfoClass AP = new AnimeInfoClass();
                AP.AnimeName = AnimeName;
                AP.AnimeThumbnailURL = ImageLocation;
                AP.AnimeSeriesURL = AnimeSeriesURL;
                Animes.Add(AP);
            }
            return Animes;
        }

        private List<AnimeInfoClass> loadAnimeViaMobile(string SearchQuery, int limit)
        {
            List<AnimeInfoClass> MobileResults = new List<AnimeInfoClass>();
            string EncodedForURLSearchQuery = System.Web.HttpUtility.UrlEncode(SearchQuery);
            PhantomObject.Navigate().GoToUrl($"http://{VariablesClass.MasterURL}/M?key=" + EncodedForURLSearchQuery + "&sort=search");
            foreach (var x in PhantomObject.FindElementsByTagName("article"))
            {
                string ImageLocation = x.FindElement(By.TagName("img")).GetAttribute("src");
                string AnimeName = x.FindElement(By.ClassName("post-content")).FindElement(By.TagName("h2")).FindElement(By.TagName("a")).Text;
                string AnimeSeriesURL = x.GetAttribute("alink");
                AnimeInfoClass AP = new AnimeInfoClass();
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

        private void buildLayout(List<AnimeInfoClass> AnimeList)
        {
            StaticsClass.InvokeIfRequired(MainFrmPanel, MainFrmPanel.SuspendLayout);
            StaticsClass.InvokeIfRequired(MainFrmPanel, () =>
            {
                while (MainFrmPanel.Controls.Count > 0)
                {
                    MainFrmPanel.Controls[0].Dispose();
                }
            });
            GC.Collect(); //clear old bitmap cache, if needed.
            StaticsClass.InvokeIfRequired(MainFrmPanel, MainFrmPanel.Controls.Clear);
            List<Control> ALIst = new List<Control> { };
            Random R = new Random();
            foreach (AnimeInfoClass AnimeInfo in AnimeList)
            {
                AnimeControl AnimeControl = new AnimeControl(AnimeInfo);
                AnimeControl.LoadAnime += startLoadingAnimeInformation;
                if (AnimeInfo.AnimeThumbnailURL.Contains(VariablesClass.MasterURL))
                {
                    AnimeControl.AnimeImage.Image = GetImage(AnimeInfo.AnimeThumbnailURL);
                }
                else
                {
                    AnimeControl.AnimeImage.ImageLocation = AnimeInfo.AnimeThumbnailURL;
                }
                ALIst.Add(AnimeControl);
            }
            StaticsClass.InvokeIfRequired(MainFrmPanel, () => MainFrmPanel.Controls.AddRange(ALIst.ToArray()));
            StaticsClass.InvokeIfRequired(MainFrmPanel, MainFrmPanel.ResumeLayout);
        }

        private Image GetImage(string ImageLocation)
        {
            byte[] data = null;
            using (CustomWebClient WC = new CustomWebClient())
            {
                WC.Headers.Add(System.Net.HttpRequestHeader.UserAgent, VariablesClass.UserAgentString);
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
            string AnimeSeriesURL = AC.AnimeInfo.AnimeSeriesURL;
            string AnimeName = AC.AnimeName.Text;
            string AnimeSynopsis = AC.AnimeInfo.AnimeSeriesSynopsis;
            string AnimeThumbnailURL = AC.AnimeImage.ImageLocation;
            LoadedAnime.AnimeName.Text = AnimeName;
            LoadedAnime.AnimeSynopsis.Text = AnimeSynopsis;
            LoadedAnime.AnimeImage.Image = AC.AnimeImage.Image;
            LoadedAnime.AnimeURL = $"http://{VariablesClass.MasterURL}" + AnimeSeriesURL;
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
                StaticsClass.InvokeIfRequired(this, () =>
                {
                    UseWaitCursor = false;
                    AnimeSearchQuery.ReadOnly = false;
                    AnimeSearchQuery.Clear();
                    AnimeSearchQuery.Visible = false;
                });
            });
            MainFrmPanel.Refresh();
            MainFrmPanel.BringToFront();
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
            PhantomObject.Quit();
            Application.Exit();
        }
    }

    class RemStripBar : ToolStripSystemRenderer
    {

        public RemStripBar()
        {

        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

    }
}