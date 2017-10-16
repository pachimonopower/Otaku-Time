using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenQA.Selenium.PhantomJS;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using MyAnimeListWrapper;

namespace Otaku_Time
{
    public partial class SingleLoadedAnime : UserControl
    {
        public string AnimeUrl = "";
        private readonly PhantomJSDriver _phantomObject;
        private PlayVideo _pv;
        private readonly DownloadingEpisodes _de;
        private string _path = "";
        private MyAnimeListAnimeInfoClass _AnimeObject;

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
            var width = EpisodesFlowPanel.Width;
            EpisodesFlowPanel.Controls.Clear();
            AnimeSynopsis.Text =  CleanSynopsis(AnimeSynopsis.Text);

            _phantomObject.Navigate().GoToUrl(AnimeUrl);
            if (needSynopsis)
            {
                AnimeSynopsis.Text = CleanSynopsis(_phantomObject.FindElementsByTagName("p")[2].Text);
            }
            var myTable = _phantomObject.FindElementsByClassName("episode");
            foreach (var node in myTable)
            {
                var epcontrol = new EpisodeControl
                {
                    Text = node.Text.Trim(),
                    Tag = node.GetAttribute("data-value")
                };
                if (StaticsClass.MyAnimeListObject != null)
                {
                    epcontrol.RateIcon.Click += RateIcon_Click;
                }
                else
                {
                    epcontrol.RateIcon.Visible = false;
                }
                EpisodesFlowPanel.Controls.Add(epcontrol);
                EpisodesFlowPanel.Controls.SetChildIndex(epcontrol, 0);
            }
            BringToFront();
        }

        private void RateIcon_Click(object sender, EventArgs e)
        {
            int.TryParse(((EpisodeControl)((PictureBox)sender).Parent).Text.ToLower().Replace("episode", "").Trim(), out int EpisodeNumber);
            RateAnimeControl RateAnimeCtrl = new RateAnimeControl(EpisodeNumber);
            Point CtrlLocation = ((PictureBox)sender).Parent.PointToScreen(Point.Empty);
            RateAnimeCtrl.Location = new Point(CtrlLocation.X, 50);
            this.Controls.Add(RateAnimeCtrl);
            RateAnimeCtrl.BringToFront();
            RateAnimeCtrl.SaveRecord += RateAnimeCtrl_SaveRecord;
        }

        private async void RateAnimeCtrl_SaveRecord(RateAnimeControl RateControl, MyAnimeListAnimeValuesClass MalValues)
        {
            await StaticsClass.MyAnimeListObject.AddAnime(_AnimeObject.Id, MalValues);
            RateControl.Dispose();

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
            EpisodesFlowPanel.Controls.Clear();
            AnimeImage.ImageLocation = "";
            AnimeName.Text = "";
            AnimeUrl = "";
            AnimeSynopsis.Text = "";
            SendToBack();
            ((MainFrm)Parent).MainFrmPanel.BringToFront();
        }

        private async void WatchNowBtn_Click(object sender, EventArgs e)
        {
            var SelectedControls = EpisodesFlowPanel.Controls.Cast<EpisodeControl>().Where(x => x.Checked).ToArray();
            if(SelectedControls.Count() == 0)
            {
                return;
            }
            var name = SelectedControls[0].Text;
            var attributeName = SelectedControls[0].Tag.ToString();
            string redirectVideoUrl;
            if (VariablesClass.MasterURL == VariablesClass.KissLewdURL)
            {
                // the so called lewd url is dodgy, but the owner doesn't captcha, so scraping is a bit easier.
                var animeurlname = _phantomObject.Url.Substring(_phantomObject.Url.LastIndexOf("/", StringComparison.Ordinal) + 1);
                redirectVideoUrl = WebDriverClass.RunViaDesktop(AnimeUrl, animeurlname, name, attributeName);
            }
            else
            {
                redirectVideoUrl = (await GetGoogleLink(attributeName)).Replace("&amp;", "&");
            }
            if (redirectVideoUrl == "no")
            {
                MessageBox.Show("Error getting stream URL. Please Try Again.");
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
        private async Task<string> GetGoogleLink(string attributeNumber)
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
                    value = await WebDriverClass.GetRapidVideoLink(alternativeSourceUrl);
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
                    await Task.Delay(300);
                    return (await GetGoogleLink(attributeNumber)).Replace("&amp;", "&"); ;
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

        public async Task GetAnimeId()
        {
            if(StaticsClass.MyAnimeListObject != null)
            {
                var AnimeEpisodes = await StaticsClass.MyAnimeListObject.SearchAnime(AnimeName.Text);
                if(AnimeEpisodes.Count > 0)
                {
                    _AnimeObject = AnimeEpisodes.First(); //Should work fine due to text matching :D
                }
            }
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
            var token = new CancellationToken();
            try
            {
                await Task.Run(() => DownloadAnime(token));
            }
            catch(OperationCanceledException)
            {
                //Messagebox disposed, stop doing this.
            }
            DownloadBtn.Enabled = true;
            WatchNowBtn.Enabled = true;
            UseWaitCursor = false;
        }

        private async void DownloadAnime(CancellationToken Token)
        {
            var vals = new Dictionary<string, string>();
            StaticsClass.InvokeIfRequired(EpisodesFlowPanel, (() => { EpisodesFlowPanel.Controls.Cast<EpisodeControl>().ToList().Where(x => x.Checked).ToList().ForEach(x => vals.Add(x.Text, x.Tag.ToString())); CloseBox.Enabled = false; }));
            foreach (var keyValPair in vals)
            {
                var episodeName = GetSafeFilename(keyValPair.Key);
                try
                {
                    _infoFrm.Invoke((MethodInvoker)(() =>
                    {
                        _infoFrm.textBox1.Text = "Downloading: " + episodeName;
                        _infoFrm.textBox1.Refresh();
                    }));
                }
                catch(ObjectDisposedException)
                {
                    Token.ThrowIfCancellationRequested();
                }
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
                    redirectorLink = (await GetGoogleLink(episodeUrl)).Replace("&amp;", "&");
                }
                 
                if (redirectorLink != "no")
                {
                    if(WebDriverClass.FileDoesNotExist(redirectorLink))
                    {
                        var animeurlname = _phantomObject.Url.Substring(_phantomObject.Url.LastIndexOf("/", StringComparison.Ordinal) + 1);
                        redirectorLink = WebDriverClass.RunViaDesktop(AnimeUrl, animeurlname, episodeName, episodeUrl);
                    }
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

        private void SingleLoadedAnime_Load(object sender, EventArgs e)
        {
            DecoratorClass.GoThroughDecorate(this);
            AnimeSynopsis.BackColor = DownloadBtn.BackColor; //for some reason doesn't paint correctly.
        }
    }
}
