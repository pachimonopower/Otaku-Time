using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace Otaku_Time
{

    public partial class SingleLoadedAnime : UserControl
    {
        public string AnimeURL = "";
        private PhantomJSDriver PhantomObject;
        private PlayVideo PV;
        private DownloadingEpisodes DE;
        private string path = "";

        private InfoFrm InfoFrm;

        public SingleLoadedAnime()
        {
            if (this.DesignMode == false)
            {
                InitializeComponent();
                PhantomObject = Statics.PhantomObject();
                DE = DownloadingEpisodes.GetMe();
            }
        }

        public void loadAnimeList(string URL, bool NeedSynopsis = false)
        {
            int width = AnimeEpisodeList.Width;
            loadCleanSynopsis();

            PhantomObject.Navigate().GoToUrl(AnimeURL);
            if (NeedSynopsis)
            {
                AnimeSynopsis.Text = PhantomObject.FindElementsByTagName("p")[2].Text;
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

        /// <summary>
        /// replaces html entities and some BQ stuff.
        /// </summary>
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

        private void WatchNowBtn_Click(object sender, EventArgs e)
        {
            string name = AnimeEpisodeList.SelectedItems[0].Text;
            string attributeName = AnimeEpisodeList.SelectedItems[0].Tag.ToString();
            string redirectVideoURL = "";
            if (Statics.MasterURL == Statics.KissLewdURL)
            {
                // the so called lewd url is dodgy, but the owner doesn't captcha, so scraping is a bit easier.
                string animeurlname = PhantomObject.Url.Substring(PhantomObject.Url.LastIndexOf("/") + 1);
                redirectVideoURL = RunViaDesktop(animeurlname, name, attributeName);
            }
            else
            {
                redirectVideoURL = GetGoogleLink(attributeName).Replace("&amp;", "&");
            }
            if (redirectVideoURL == "no")
            {
                return;
            }
            if (PV == null || PV.Player == null)
            {
                CreatePlayerInstance(name, redirectVideoURL);
            }
            else
            {
                if (PV.Player.isPlaying == true)
                {
                    MyMessageBox MSB = new MyMessageBox("You're already playing an anime, would you like to queue or watch now?", "Otaku Time", "Queue", "Watch Now");
                    MSB.Load();
                    string response = MSB.Response;

                    if (response == "Queue")
                    {
                        PV.addToQueue(name, redirectVideoURL);
                    }
                    else if (response == "Watch Now")
                    {
                        CreatePlayerInstance(name, redirectVideoURL);
                    }
                }
                else
                {
                    CreatePlayerInstance(name, redirectVideoURL);
                }
            }
        }

        /// <summary>
        /// Scrapes the desktop site for web info. Currently only supports the lewd URL
        /// </summary>
        /// <param name="animeurlname"></param>
        /// <param name="name"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        private string RunViaDesktop(string animeurlname, string name, string attributeName)
        {
            string endpoint = $"http://{Statics.KissLewdURL}/Hentai/{animeurlname}/{name.Replace(" ", "-")}?id={attributeName}";
            string value = "";
            PhantomObject.Navigate().GoToUrl(endpoint);
            PhantomObject.ExecuteScript("$('#selectServer').val('openload').change();");
            Thread.Sleep(1000);
            var xo = PhantomObject.FindElementsByTagName("a").FirstOrDefault(x => x.Text.Contains("CLICK HERE"));
            if(xo != null)
            {
                value = Statics.GetOpenloadLink(xo.GetAttribute("href"));
            }
            PhantomObject.Navigate().GoToUrl(AnimeURL);
            return value;
        }

        private void CreatePlayerInstance(string name, string redirectVideoUrl)
        {
            PV = new PlayVideo(name, redirectVideoUrl);
            PV.FormClosing += (s, ev) => PV = null;
            PV.Show();
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
            string AlternativeSourceUrl = "";
            try
            {
                AlternativeSourceUrl = PhantomObject.FindElementById("mVideo").GetAttribute("src");
            }
            catch (Exception) { }
            if (!string.IsNullOrWhiteSpace(AlternativeSourceUrl))
            {
                string value = "";
                if (AlternativeSourceUrl.Contains("openload")) value = Statics.GetOpenloadLink(AlternativeSourceUrl);
                else if (AlternativeSourceUrl.Contains("rapidvideo")) value = GetRapidVideoLink(AlternativeSourceUrl);
                else value = AlternativeSourceUrl; // its the google link. weird.
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

        private string GetRapidVideoLink(string openloadurl)
        {
            PhantomObject.Navigate().GoToUrl(openloadurl);
            string value = "";
            try
            {
                var matches = System.Text.RegularExpressions.Regex.Matches(PhantomObject.PageSource, "\"sources\":(.*),\"logo\"");
                string JsonVals = matches[0].Groups[1].Value;  // first match, second group.
                Newtonsoft.Json.Linq.JToken Token = Newtonsoft.Json.Linq.JToken.Parse(JsonVals);
                List<Newtonsoft.Json.Linq.JToken> VideoTokens = Token.Children().OrderByDescending(x => int.Parse(x.SelectToken("label").ToString().Replace("p", ""))).ToList();
                value = VideoTokens.First().SelectToken("file").ToString();
            }
            catch (Exception)
            {
                value = "no";
            }

            return value;
        }

        private async void DownloadBtn_Click(object sender, EventArgs e)
        {
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
            DownloadBtn.Enabled = false;
            WatchNowBtn.Enabled = false;
            await Task.Run((Action)DownloadAnime);
            DownloadBtn.Enabled = true;
            WatchNowBtn.Enabled = true;
            UseWaitCursor = false;
        }

        private void DownloadAnime()
        {
            Dictionary<string, string> Vals = new Dictionary<string, string>();
            if (AnimeEpisodeList.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => { AnimeEpisodeList.SelectedItems.Cast<ListViewItem>().ToList().ForEach(x => Vals.Add(x.Text, x.Tag.ToString())); CloseBox.Enabled = false; }));
            }
            else
            {
                AnimeEpisodeList.SelectedItems.Cast<ListViewItem>().ToList().ForEach(x => Vals.Add(x.Text, x.Tag.ToString()));
                CloseBox.Enabled = false;
            }
            foreach (KeyValuePair<string, string> KeyValPair in Vals)
            {
                string episodeName = GetSafeFilename(KeyValPair.Key);
                InfoFrm.Invoke((MethodInvoker)(() =>
                {
                    InfoFrm.textBox1.Text = "Downloading: " + episodeName;
                    InfoFrm.textBox1.Refresh();
                }));
                string episodeURL = KeyValPair.Value;
                string directoryPath = path + @"\" + GetSafeFilename(AnimeName.Text);
                Directory.CreateDirectory(directoryPath);
                string redirectorLink = "";
                if (Statics.MasterURL == Statics.KissLewdURL)
                {
                    string animeurlname = PhantomObject.Url.Substring(PhantomObject.Url.LastIndexOf("/") + 1);
                    redirectorLink = RunViaDesktop(animeurlname, episodeName, episodeURL);
                }
                else
                {
                    redirectorLink = GetGoogleLink(episodeURL).Replace("&amp;", "&");
                }
                 
                if (redirectorLink != "no")
                {
                    this.Invoke((MethodInvoker)(() => DE.addDownload(redirectorLink, episodeName, directoryPath)));
                }
            }
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    CloseBox.Enabled = true;
                    InfoFrm.Close();
                }));
            }
            else
            {
                CloseBox.Enabled = true;
                InfoFrm.Close();
            }
        }

        private string GetSafeFilename(string filename)
        {

            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

        }
    }
}
