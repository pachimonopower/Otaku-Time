using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Otaku_Time
{

    public partial class SingleLoadedAnime : UserControl
    {
        public string AnimeURL = "";
        private PhantomJSDriver PhantomObject;
        private PlayVideo PV;
        private DownloadingEpisodes DE;
        private string path = "";
        public static string response = "";

        private InfoFrm InfoFrm;

        public SingleLoadedAnime()
        {

            if (this.DesignMode == false)
            {
                InitializeComponent();
                PhantomObject = PhantomFactory.ReturnDriver();
                DE = DownloadingEpisodes.GetMe();
            }

        }

        private void SingleLoadedAnime_Load(object sender, EventArgs e)
        {
            var parentFrm = Parent;
        }

        public void loadAnimeList(string URL, bool NeedSynopsis = false)
        {
            int width = AnimeEpisodeList.Width;
            loadCleanSynopsis();

            PhantomObject.Navigate().GoToUrl(AnimeURL);
            HtmlAgilityPack.HtmlDocument SeriesDocument = new HtmlAgilityPack.HtmlDocument();
            SeriesDocument.LoadHtml(PhantomObject.PageSource);
            if (NeedSynopsis)
            {
                AnimeSynopsis.Text = PhantomObject.FindElementsByTagName("span").Last().Text;
                loadCleanSynopsis();
            }
            var myTable = PhantomObject.FindElementsByClassName("episode");
            foreach (IWebElement node in myTable)
            {
                ListViewItem LVI = new ListViewItem();
                LVI.Text = node.Text.Trim();
                LVI.Tag = node.GetAttribute("data-value");
                AnimeEpisodeList.Items.Add(LVI);
            }
            AnimeEpisodeList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (AnimeEpisodeList.Columns[0].Width > 261)
            {
                this.AnimeEpisodeList.Size = new Size(AnimeEpisodeList.Columns[0].Width + 20, AnimeEpisodeList.Height);
                width = AnimeEpisodeList.Columns[0].Width - width;
                Parent.Width += width;
            }
            this.BringToFront();
        }

        private void loadCleanSynopsis()
        {
            string newstring = AnimeSynopsis.Text
              .Replace("<br />", "")
              .Replace("&quot;", "\"")
              .Replace("&ldquo;", "\"")
              .Replace("&mdash;", "-")
              .Replace("&#039;", "'")
              .Replace("[i]", "")
              .Replace("[/i]", "");

            if (newstring.LastIndexOf(Environment.NewLine) > 0)
            {
                newstring = newstring.Substring(0, newstring.LastIndexOf(Environment.NewLine));
            }
            AnimeSynopsis.Text = newstring;


        }

        private void CloseThisPanel(object sender, EventArgs e)
        {
            AnimeEpisodeList.Items.Clear();
            AnimeImage.ImageLocation = "";
            AnimeName.Text = "";
            AnimeURL = "";
            AnimeSynopsis.Text = "";
            this.SendToBack();
            ((MainFrm)Parent).MainFrmPanel.BringToFront();
        }

        public void closeMe()
        {

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => CloseThisPanel(CloseBox, null)));
            }
            else
            {
                CloseThisPanel(CloseBox, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = AnimeEpisodeList.SelectedItems[0].Text;
            string attributeName = AnimeEpisodeList.SelectedItems[0].Tag.ToString();
            string redirectVideoURL = GetGoogleLink(attributeName).Replace("&amp;", "&");
            if (redirectVideoURL == "no")
            {
                return;
            }
            if (PV == null || PV.Player == null)
            {
                PV = new PlayVideo(name, redirectVideoURL);
                PV.FormClosing += PV_FormClosing;
                PV.Show();
            }
            else
            {
                if (PV.Player.isPlaying == true)
                {
                    MyMessageBox MSB = new MyMessageBox("You're already playing an anime, would you like to queue or watch now?", "Otaku Time", "Queue", "Watch Now");
                    MSB.Load();
                    do
                    {
                        Application.DoEvents();
                    }
                    while (response.Trim() == "");

                    if (response == "Queue")
                    {
                        PV.addToQueue(name, redirectVideoURL);
                    }
                    else if (response == "Watch Now")
                    {
                        PV.Dispose();
                        PV = new PlayVideo(name, redirectVideoURL);
                        PV.FormClosing += PV_FormClosing;
                        PV.Show();
                    }
                    response = "";

                }
                else
                {
                    PV.Dispose();
                    PV = new PlayVideo(name, redirectVideoURL);
                    PV.FormClosing += PV_FormClosing;
                    PV.Show();
                }
            }
        }

        private void PV_FormClosing(object sender, FormClosingEventArgs e)
        {
            PV = null;
        }

        private bool clicked = false;
        private int tryCount = 0;
        private string GetGoogleLink(string attributeNumber)
        {
            tryCount++;
            if (clicked == false)
            {
                PhantomObject.Navigate().Refresh();
                IWebElement RunTheScript = PhantomObject.FindElementsByClassName("episode").Where(x => x.GetAttribute("data-value") == attributeNumber).First();
                RunTheScript.Click();
                clicked = true;
            }
            var firstpreval = PhantomObject.FindElementsByTagName("a");
            var secondspreval = firstpreval.Where(x => x.Text != "").Select(x => x).ToList();
            var val = secondspreval.Where(x => x.Text.Contains("mp4")).FirstOrDefault();
            string openloadurl = "";
            try
            {
                openloadurl = PhantomObject.FindElementById("mVideo").GetAttribute("src");
            }
            catch (Exception) { }
            if (!string.IsNullOrWhiteSpace(openloadurl))
            {
                string value = "";
                if (openloadurl.Contains("openload")) value = GetOpenloadLink(openloadurl);
                else value = openloadurl; // its the google link. weird.
                PhantomObject.Navigate().GoToUrl(AnimeURL);
                clicked = false;
                return value;
            }
            if (val == null)
            {
                if (tryCount <= 5)
                {
                    Thread.Sleep(300);
                    return GetGoogleLink(attributeNumber).Replace("&amp;", "&"); ;
                }
                else
                {
                    MessageBox.Show("Video is unavailable, please try again later.", "Otaku Time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tryCount = 0;
                    return "no";
                }

            }
            tryCount = 0;
            string retval = val.GetAttribute("href");
            clicked = false;
            return retval;

        }

        private string GetOpenloadLink(string openloadurl)
        {
            string retval = "";
            openloadurl = openloadurl.Replace("embed", "f");
            PhantomObject.Navigate().GoToUrl(openloadurl);
            if (PhantomObject.Title.Contains("404"))
            {
                Thread.Sleep(100);
                PhantomObject.Navigate().GoToUrl(openloadurl); // the 404 is an openload bug it seems.
            }
            try
            {
                PhantomObject.FindElementById("btnDl").Click();
            }
            catch (Exception)
            {
                return "no";
            }
            Thread.Sleep(6000);
            PhantomObject.FindElementById("downloadTimer").Click();
            var possibles = PhantomObject.FindElementsByClassName("dlbutton").Where(x => x.GetAttribute("href") != null).FirstOrDefault();
            if (possibles == null)
            {
                retval = "no";
            }
            else
            {
                retval = possibles.GetAttribute("href");
            }
            return retval;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DownloadWorker.IsBusy)
            {
                return;
            }
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            var result = FBD.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            path = FBD.SelectedPath;
            UseWaitCursor = true;
            InfoFrm = new InfoFrm();
            InfoFrm.Show();
            InfoFrm.BringToFront();
            DownloadWorker.RunWorkerAsync();
            UseWaitCursor = false;
        }

        private void DownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, string> Vals = new Dictionary<string, string>();
            if (AnimeEpisodeList.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => {AnimeEpisodeList.SelectedItems.Cast<ListViewItem>().ToList().ForEach(x => Vals.Add(x.Text, x.Tag.ToString()));  CloseBox.Enabled = false; }));
            }
            else
            {
                AnimeEpisodeList.SelectedItems.Cast<ListViewItem>().ToList().ForEach(x => Vals.Add(x.Text, x.Tag.ToString()));
                CloseBox.Enabled = false;
            }
            foreach (KeyValuePair<string, string> value in Vals)
            {
                string episodeName = GetSafeFilename(value.Key);
                InfoFrm.Invoke((MethodInvoker)(() =>
                {
                    InfoFrm.textBox1.Text = "Downloading: " + episodeName;
                    InfoFrm.textBox1.Refresh();
                }));
                string episodeURL = value.Value;
                string directoryPath = path + @"\" + GetSafeFilename(AnimeName.Text);
                Directory.CreateDirectory(directoryPath);

                string redirectorLink = GetGoogleLink(episodeURL).Replace("&amp;", "&");
                if (redirectorLink != "no")
                {
                    this.Invoke((MethodInvoker)(() => DE.addDownload(redirectorLink, episodeName, directoryPath)));
                }
            }
            if (AnimeEpisodeList.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => CloseBox.Enabled = true));
            }
            else
            {
                CloseBox.Enabled = true;
            }
        }

        private string GetSafeFilename(string filename)
        {

            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

        }
    }
}
