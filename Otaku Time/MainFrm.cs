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

namespace Otaku_Time
{

    public partial class MainFrm : Form
    {
        public PhantomJSDriver PhantomObject;
        private int counter = 0;
        private SplashFrm splash;
        public DownloadingEpisodes DE;
        private List<AnimePane> animeBuilder;

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

            if (this.DesignMode == false)
            {
                PhantomObject = PhantomFactory.ReturnDriver();
                splash = new SplashFrm();
                new Thread(() => splash.ShowDialog()).Start();
                DE = DownloadingEpisodes.GetMe();
                DE.Hide();

            }
            VersionTxt.Text += Application.ProductVersion;
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {

            if (this.DesignMode == false)
            {
                PhantomObject.Navigate().GoToUrl("http://kissanime.to/M");
                optionStrip.Renderer = new RemStripBar();
                this.Hide();
                getAuth();
            }

        }
        private void MoveThisform(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
        private void getAuth()
        {
            if (PhantomObject.Title.Contains("Please wait 5 seconds"))
            {
                if (splash.WhatDoing.InvokeRequired)
                    splash.WhatDoing.Invoke((MethodInvoker)(() => splash.WhatDoing.Text = "Gaining authentication from server."));
                else
                    splash.WhatDoing.Text = "Gaining authentication from server.";
                if (counter != 4)
                {
                    if (splash.Progress.InvokeRequired)
                        splash.WhatDoing.Invoke((MethodInvoker)(() => splash.Progress.PerformStep()));
                    else
                        splash.Progress.PerformStep();
                    counter++;
                }
                System.Threading.Thread.Sleep(2000);
                getAuth();
            }
            else
            {
                if (splash.WhatDoing.InvokeRequired)
                    splash.WhatDoing.Invoke((MethodInvoker)(() => splash.WhatDoing.Text = "Filling program with anime!"));
                else
                    splash.WhatDoing.Text = "Filling program with anime!";
                if (splash.Progress.InvokeRequired)
                    splash.WhatDoing.Invoke((MethodInvoker)(() => splash.Progress.PerformStep()));
                else
                    splash.Progress.PerformStep();
                buildLayout(MainMobileUpdates());
                if (splash.Progress.InvokeRequired)
                    splash.WhatDoing.Invoke((MethodInvoker)(() => splash.Progress.PerformStep()));
                else
                    splash.Progress.PerformStep();
                if (splash.InvokeRequired)
                    splash.Invoke((MethodInvoker)(() => splash.Dispose()));
                else
                    splash.Dispose();
                this.Show();
            }
        }
        private List<AnimePane> MainMobileUpdates()
        {
            List<AnimePane> Animes = new List<AnimePane>();

            if (PhantomObject.Title.Contains("KissAnime Mobile") == false)
                PhantomObject.Navigate().GoToUrl("http://kissanime.to/m");
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

        private List<AnimePane> loadAnime(string SearchQuery, int limit, bool UseMobile = false)
        {
            if (UseMobile)
                return loadAnimeViaMobile(SearchQuery, limit);
            PhantomObject.Navigate().GoToUrl("http://kissanime.to/AdvanceSearch");
            do
            {
                PhantomObject.Navigate().Refresh();
                Thread.Sleep(2000);
            }
            while (PhantomObject.PageSource.Contains("The service is unavailable."));
            PhantomObject.FindElementById("animeName").SendKeys(SearchQuery);
            PhantomObject.FindElementById("btnSubmit").Click();

            List<AnimePane> correctNodes = new List<AnimePane> { };
            string PageSource = PhantomObject.PageSource;
            HtmlAgilityPack.HtmlDocument SeriesDocument = new HtmlAgilityPack.HtmlDocument();
            SeriesDocument.LoadHtml(PageSource);
            var collection = SeriesDocument.DocumentNode.Descendants("tr");
            int counter = 0;
            foreach (HtmlNode node in collection)
            {
                if (counter == limit)
                {
                    counter = 0;
                    break;
                }
                try
                {
                    HtmlNode realParent = node.SelectSingleNode("td");
                    if (realParent == null)
                    {
                        continue;
                    }
                    AnimePane AnimeCriteria = new AnimePane();
                    AnimeCriteria.AnimeSeriesURL = realParent.SelectSingleNode("a").GetAttributeValue("href", "N/A");
                    AnimeCriteria.AnimeName = realParent.SelectSingleNode("a").InnerHtml;
                    AnimeCriteria.AnimeName = AnimeCriteria.AnimeName.Replace(@"\r\n", "").Trim();
                    string[] animeInfo = getAnimeInfo(AnimeCriteria.AnimeName);
                    AnimeCriteria.AnimeThumbnailURL = animeInfo[0];
                    AnimeCriteria.AnimeSeriesSynopsis = animeInfo[1];
                    correctNodes.Add(AnimeCriteria);
                    counter++;
                }
                catch (Exception)
                {
                    continue;
                }

            }
            return correctNodes;
        }

        private List<AnimePane> loadAnimeViaMobile(string SearchQuery, int limit)
        {
            List<AnimePane> MobileResults = new List<AnimePane>();
            string EncodedForURLSearchQuery = System.Web.HttpUtility.UrlEncode(SearchQuery);
            PhantomObject.Navigate().GoToUrl("http://kissanime.ru/M?key=" + EncodedForURLSearchQuery + "&sort=search");
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

        private string[] getAnimeInfo(string animeName)
        {
            List<string> animeInfo = new List<string> { };
            try
            {
                using (WebClient WC = new WebClient())
                {
                    WC.Credentials = new NetworkCredential("", ""); //MyAnimeList credentials for loading images and info.
                    string WhichAnime = "https://myanimelist.net/api/anime/search.xml?q=" + animeName.ToLower().Replace("(dub)", "").Replace("(sub)", "");
                    string XML = WC.DownloadString(WhichAnime);
                    XmlDocument XDoc = new XmlDocument();
                    XDoc.LoadXml(XML);
                    animeInfo.Add(XDoc.GetElementsByTagName("image").Item(0).InnerText);
                    animeInfo.Add(XDoc.GetElementsByTagName("synopsis").Item(0).InnerText);
                    return animeInfo.ToArray();
                }
            }
            catch (Exception)
            {
                animeInfo.Add("https://s-media-cache-ak0.pinimg.com/564x/f0/ef/07/f0ef0713a46529d57536b07064d7562e.jpg");
                animeInfo.Add("N/A");
                return animeInfo.ToArray();
            }
        }

        private void buildLayout(List<AnimePane> AnimeList)
        {
            MainFrmPanel.SuspendLayout();
            if (MainFrmPanel.InvokeRequired)
                MainFrmPanel.Invoke((MethodInvoker)(() => MainFrmPanel.Controls.Clear()));
            else
                MainFrmPanel.Controls.Clear();
            List<Control> ALIst = new List<Control> { };
            foreach (AnimePane SinglePane in AnimeList)
            {
                AnimeControl AC = new AnimeControl();
                AC.AnimeName.Text = SinglePane.AnimeName;
                AC.AnimeImage.ImageLocation = SinglePane.AnimeThumbnailURL;
                AC.AnimeURL = SinglePane.AnimeSeriesURL;
                AC.AnimeSynposis = SinglePane.AnimeSeriesSynopsis;
                ALIst.Add(AC);
            }
            if (MainFrmPanel.InvokeRequired)
                MainFrmPanel.Invoke((MethodInvoker)(() => MainFrmPanel.Controls.AddRange(ALIst.ToArray())));
            else
                MainFrmPanel.Controls.AddRange(ALIst.ToArray());
            MainFrmPanel.ResumeLayout();
        }

        private void searchAnime(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AnimeSearchQuery.ReadOnly = true;
                if (LoadAnimeWorker.IsBusy)
                    LoadAnimeWorker.CancelAsync();
                while (LoadAnimeWorker.CancellationPending)
                    Application.DoEvents();
                LoadAnimeWorker.RunWorkerAsync();
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
            LoadedAnime.AnimeImage.ImageLocation = AnimeThumbnailURL;
            LoadedAnime.AnimeURL = "https://kissanime.to" + AnimeSeriesURL;
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
        }

        private void LoadAnimeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadedAnime.closeMe();
            UseWaitCursor = true;
            if (LoadAnimeWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            animeBuilder = loadAnime(AnimeSearchQuery.Text, 999, true);
        }

        private void LoadAnimeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buildLayout(animeBuilder);
            AnimeSearchQuery.ReadOnly = false;
            UseWaitCursor = false;
            AnimeSearchQuery.Clear();
            AnimeSearchQuery.Visible = false;
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
    }
}