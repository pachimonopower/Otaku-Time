using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenQA.Selenium.PhantomJS;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace Otaku_Time
{
    public partial class SingleLoadedAnime : UserControl
    {
        public string AnimeUrl = "";
        private readonly PhantomJSDriver _phantomObject;
        private PlayVideo _pv;
        private readonly DownloadingEpisodes _de;
        private string _path = "";

        private InfoFrm _infoFrm;

        public SingleLoadedAnime()
        {
            _tryCount = 0;
            if (DesignMode == false)
            {
                InitializeComponent();
                _phantomObject = WebDriverClass.PhantomJSInstance;
                _de = DownloadingEpisodes.GetMe();
            }
        }

        public void LoadAnimeList(bool needSynopsis = false)
        {
            var width = AnimeEpisodeList.Width;
            AnimeSynopsis.Text =  CleanSynopsis(AnimeSynopsis.Text);

            _phantomObject.Navigate().GoToUrl(AnimeUrl);
            if (needSynopsis)
            {
                AnimeSynopsis.Text = CleanSynopsis(_phantomObject.FindElementsByTagName("p")[2].Text);
            }
            var myTable = _phantomObject.FindElementsByClassName("episode");
            foreach (var node in myTable)
            {
                var lvi = new ListViewItem
                {
                    Text = node.Text.Trim (),
                    Tag = node.GetAttribute ("data-value")
                };
                AnimeEpisodeList.Items.Add(lvi);
            }
            AnimeEpisodeList.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (AnimeEpisodeList.Columns[0].Width > 261)
            {
                AnimeEpisodeList.Size = new Size(AnimeEpisodeList.Columns[0].Width + 20, AnimeEpisodeList.Height);
                width = AnimeEpisodeList.Columns[0].Width - width;
                Parent.Width += width;
            }
            BringToFront();
        }

        /// <summary>
        /// replaces html entities and some BQ stuff.
        /// </summary>
        private static string CleanSynopsis(string dirtySynopsis)
        {
            var newstring = dirtySynopsis
              .Replace("<br />", "")
              .Replace("&quot;", "\"")
              .Replace("&ldquo;", "\"")
              .Replace("&mdash;", "-")
              .Replace("&#039;", "'")
              .Replace("[i]", "")
              .Replace("[/i]", "");

            if (newstring.LastIndexOf(Environment.NewLine, StringComparison.Ordinal) > 0)
            {
                newstring = newstring.Substring(0, newstring.LastIndexOf(Environment.NewLine, StringComparison.Ordinal));
            }
            return newstring;
        }

        private void CloseThisPanel(object sender, EventArgs e)
        {
            AnimeEpisodeList.Items.Clear();
            AnimeImage.ImageLocation = "";
            AnimeName.Text = "";
            AnimeUrl = "";
            AnimeSynopsis.Text = "";
            SendToBack();
            ((MainFrm)Parent).MainFrmPanel.BringToFront();
        }

        private void WatchNowBtn_Click(object sender, EventArgs e)
        {
            var name = AnimeEpisodeList.SelectedItems[0].Text;
            var attributeName = AnimeEpisodeList.SelectedItems[0].Tag.ToString();
            string redirectVideoUrl;
            if (VariablesClass.MasterURL == VariablesClass.KissLewdURL)
            {
                // the so called lewd url is dodgy, but the owner doesn't captcha, so scraping is a bit easier.
                var animeurlname = _phantomObject.Url.Substring(_phantomObject.Url.LastIndexOf("/", StringComparison.Ordinal) + 1);
                redirectVideoUrl = WebDriverClass.RunViaDesktop(AnimeUrl, animeurlname, name, attributeName);
            }
            else
            {
                redirectVideoUrl = GetGoogleLink(attributeName).Replace("&amp;", "&");
            }
            if (redirectVideoUrl == "no")
            {
                return;
            }
            if (_pv == null || _pv.Player == null)
            {
                CreatePlayerInstance(name, redirectVideoUrl);
            }
            else
            {
                if (_pv.Player.isPlaying)
                {
                    var msb = new MyMessageBox("You're already playing an anime, would you like to queue or watch now?", "Otaku Time", "Queue", "Watch Now");
                    msb.Load();
                    var response = msb.Response;

                    if (response == "Queue")
                    {
                        _pv.addToQueue(name, redirectVideoUrl);
                    }
                    else if (response == "Watch Now")
                    {
                        CreatePlayerInstance(name, redirectVideoUrl);
                    }
                }
                else
                {
                    CreatePlayerInstance(name, redirectVideoUrl);
                }
            }
        }

        private void CreatePlayerInstance(string name, string redirectVideoUrl)
        {
            _pv = new PlayVideo(name, redirectVideoUrl);
            _pv.FormClosing += (s, ev) => _pv = null;
            _pv.Show();
        }

        private bool _clicked;
        private int _tryCount;
        private string GetGoogleLink(string attributeNumber)
        {
            _tryCount++;
            if (_clicked == false)
            {
                _phantomObject.Navigate().Refresh();
                var runTheScript = _phantomObject.FindElementsByClassName("episode").First(x => x.GetAttribute("data-value") == attributeNumber);
                runTheScript.Click();
                _clicked = true;
            }
            var firstpreval = _phantomObject.FindElementsByTagName("a");
            var secondspreval = firstpreval.Where(x => x.Text != "").Select(x => x).ToList();
            var val = secondspreval.FirstOrDefault(x => x.Text.Contains("mp4"));
            var alternativeSourceUrl = "";
            try
            {
                alternativeSourceUrl = _phantomObject.FindElementById("mVideo").GetAttribute("src");
            }
            catch (Exception) { }
            if (!string.IsNullOrWhiteSpace(alternativeSourceUrl))
            {
                string value;
                if (alternativeSourceUrl.Contains("openload"))
                    value = StaticsClass.GetOpenloadLink(alternativeSourceUrl);
                else if (alternativeSourceUrl.Contains("rapidvideo"))
                    value = WebDriverClass.GetRapidVideoLink(alternativeSourceUrl);
                else
                    value = alternativeSourceUrl; // its the google link. weird.
                _phantomObject.Navigate().GoToUrl(AnimeUrl);
                _clicked = false;
                return value;
            }
            if (val == null)
            {
                if (_tryCount <= 5)
                {
                    Thread.Sleep(300);
                    return GetGoogleLink(attributeNumber).Replace("&amp;", "&"); ;
                }
                MessageBox.Show("Video is unavailable, please try again later.", "Otaku Time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _tryCount = 0;
                return "no";
            }
            _tryCount = 0;
            var retval = val.GetAttribute("href");
            _clicked = false;
            return retval;
        }

        private async void DownloadBtn_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            _path = fbd.SelectedPath;
            UseWaitCursor = true;
            _infoFrm = new InfoFrm();
            _infoFrm.Show();
            _infoFrm.BringToFront();
            DownloadBtn.Enabled = false;
            WatchNowBtn.Enabled = false;
            await Task.Run((Action)DownloadAnime);
            DownloadBtn.Enabled = true;
            WatchNowBtn.Enabled = true;
            UseWaitCursor = false;
        }

        private void DownloadAnime()
        {
            var vals = new Dictionary<string, string>();
            if (AnimeEpisodeList.InvokeRequired)
            {
                Invoke((MethodInvoker)(() => { AnimeEpisodeList.SelectedItems.Cast<ListViewItem>().ToList().ForEach(x => vals.Add(x.Text, x.Tag.ToString())); CloseBox.Enabled = false; }));
            }
            else
            {
                AnimeEpisodeList.SelectedItems.Cast<ListViewItem>().ToList().ForEach(x => vals.Add(x.Text, x.Tag.ToString()));
                CloseBox.Enabled = false;
            }
            foreach (var keyValPair in vals)
            {
                var episodeName = GetSafeFilename(keyValPair.Key);
                _infoFrm.Invoke((MethodInvoker)(() =>
                {
                    _infoFrm.textBox1.Text = "Downloading: " + episodeName;
                    _infoFrm.textBox1.Refresh();
                }));
                var episodeUrl = keyValPair.Value;
                var directoryPath = _path + @"\" + GetSafeFilename(AnimeName.Text);
                Directory.CreateDirectory(directoryPath);
                string redirectorLink;
                if (VariablesClass.MasterURL == VariablesClass.KissLewdURL)
                {
                    var animeurlname = _phantomObject.Url.Substring(_phantomObject.Url.LastIndexOf("/", StringComparison.Ordinal) + 1);
                    redirectorLink = WebDriverClass.RunViaDesktop(AnimeUrl, animeurlname, episodeName, episodeUrl);
                }
                else
                {
                    redirectorLink = GetGoogleLink(episodeUrl).Replace("&amp;", "&");
                }
                 
                if (redirectorLink != "no")
                {
                    Invoke((MethodInvoker)(() => _de.addDownload(redirectorLink, episodeName, directoryPath)));
                }
            }
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CloseBox.Enabled = true;
                    _infoFrm.Close();
                }));
            }
            else
            {
                CloseBox.Enabled = true;
                _infoFrm.Close();
            }
        }

        private static string GetSafeFilename(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
