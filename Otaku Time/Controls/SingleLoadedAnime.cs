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
        private bool _clicked;
        private int _tryCount;
        private InfoFrm _InfoFrm;

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
            AnimeSynopsis.Text = CleanSynopsis(AnimeSynopsis.Text);

            var splitData = AnimeUrl.Split('/');
            splitData[splitData.Length - 1] = System.Web.HttpUtility.UrlEncode(splitData.Last(), System.Text.Encoding.UTF8);
            AnimeUrl = string.Join("/", splitData);

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

            foreach (EpisodeControl item in EpisodesFlowPanel.Controls)
            {
                item.CheckChanged += new EventHandler((sender, e) => {
                    AllCheck.CheckedChanged -= AllCheck_CheckedChanged;
                    var checkCount = 0;
                    foreach (EpisodeControl checkItem in EpisodesFlowPanel.Controls)
                    {
                        if (checkItem.Checked) checkCount++;
                    }
                    if (checkCount == 0)
                    {
                        AllCheck.CheckState = CheckState.Unchecked;
                    }
                    else if (checkCount == EpisodesFlowPanel.Controls.Count)
                    {
                        AllCheck.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        AllCheck.CheckState = CheckState.Indeterminate;
                    }
                    AllCheck.CheckedChanged += AllCheck_CheckedChanged;
                });
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

        private async void WatchNow(object sender, EventArgs e)
        {
            var SelectedControls = EpisodesFlowPanel.Controls.Cast<EpisodeControl>().Where(x => x.Checked).ToArray();
            if (SelectedControls.Count() == 0)
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

        private async Task<string> GetGoogleLink(string attributeNumber)
        {
            _tryCount++;
            if (_clicked == false)
            {
                while (true)
                {
                    try
                    {
                        _phantomObject.Navigate().Refresh();
                        break;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(1000);
                    }
                }
                _phantomObject.Navigate().Refresh();
                var runTheScript = _phantomObject.FindElementsByClassName("episode").First(x => x.GetAttribute("data-value") == attributeNumber);
                runTheScript.Click();
                _clicked = true;
            }
            var firstpreval = _phantomObject.FindElementsByTagName("a");
            var secondspreval = firstpreval.Where(x => x.Text != "").Select(x => x).ToList();
            var val = secondspreval.FirstOrDefault(x => x.Text.Contains("mp4"));
            var alternativeSourceUrl = "";
            for (var i = 0; i < 100; i++)
            {
                if (!string.IsNullOrWhiteSpace(alternativeSourceUrl)) break;
                try
                {
                    alternativeSourceUrl = _phantomObject.FindElementById("mVideo").GetAttribute("src");
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }
            try
            {
                if (!string.IsNullOrWhiteSpace(alternativeSourceUrl))
                {
                    string value;
                    if (GetRawURL.Checked)
                    {
                        value = alternativeSourceUrl;
                    }
                    else
                    {
                        if (alternativeSourceUrl.Contains("openload"))
                            value = StaticsClass.GetOpenloadLink(alternativeSourceUrl);
                        else if (alternativeSourceUrl.Contains("rapidvideo"))
                            value = await WebDriverClass.GetRapidVideoLink(alternativeSourceUrl);
                        else
                            value = alternativeSourceUrl; // its the google link. weird.
                    }
                    _phantomObject.Navigate().GoToUrl(AnimeUrl);
                    _clicked = false;
                    return value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (StaticsClass.MyAnimeListObject != null)
            {
                var AnimeEpisodes = await StaticsClass.MyAnimeListObject.SearchAnime(AnimeName.Text);
                if (AnimeEpisodes.Count > 0)
                {
                    _AnimeObject = AnimeEpisodes.First(); //Should work fine due to text matching :D
                }
            }
        }

        private async void DownloadNow(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            _path = fbd.SelectedPath;
            UseWaitCursor = true;
            DownloadBtn.Enabled = false;
            WatchNowBtn.Enabled = false;
            GetUrlsBtn.Enabled = false;
            var token = new CancellationToken();
            try
            {
                await Task.Run(async () =>
                {
                    var vals = new Dictionary<string, string>();
                    StaticsClass.InvokeIfRequired(EpisodesFlowPanel, (() => { EpisodesFlowPanel.Controls.Cast<EpisodeControl>().ToList().Where(x => x.Checked).ToList().ForEach(x => vals.Add(x.Text, x.Tag.ToString())); CloseBox.Enabled = false; }));
                    var directoryPath = _path + @"\" + GetSafeFilename(AnimeName.Text);
                    Directory.CreateDirectory(directoryPath);
                    var Urls = await GetDownloadUrls(vals, "Downloading");
                    foreach (var keyValPair in Urls)
                    {
                        var ActualUrl = keyValPair.Value;
                        var EpisodeNum = keyValPair.Key;
                        Invoke((MethodInvoker)(() => _de.addDownload(ActualUrl, EpisodeNum, directoryPath)));
                    }
                    StaticsClass.InvokeIfRequired(this, () => CloseBox.Enabled = true);
                }, token);
            }
            catch (OperationCanceledException)
            {
                //Messagebox disposed, stop doing this.
            }
            DownloadBtn.Enabled = true;
            WatchNowBtn.Enabled = true;
            GetUrlsBtn.Enabled = true;
            UseWaitCursor = false;
        }

        private static string GetSafeFilename(string filename, string replaceChar = "_")
        {
            return string.Join(replaceChar, filename.Split(Path.GetInvalidFileNameChars()));
        }

        private void SingleLoadedAnime_Load(object sender, EventArgs e)
        {
            DecoratorClass.GoThroughDecorate(this);
            AnimeSynopsis.BackColor = DownloadBtn.BackColor; //for some reason doesn't paint correctly.
        }

        private async void GetDownloadUrlsClick(object sender, EventArgs e)
        {
            var availableAnimeName = GetSafeFilename(AnimeName.Text);
            var sfd = new SaveFileDialog() { FileName = availableAnimeName + ".txt", Filter = "Text File|*.txt;", RestoreDirectory = true, InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            var vals = new Dictionary<string, string>();
            StaticsClass.InvokeIfRequired(EpisodesFlowPanel, (() => { EpisodesFlowPanel.Controls.Cast<EpisodeControl>().ToList().Where(x => x.Checked).ToList().ForEach(x => vals.Add(x.Text, x.Tag.ToString())); CloseBox.Enabled = false; }));
            var urls = await Task.Run(() => GetDownloadUrls(vals, "Getting URL For"));
            using (var sw = new StreamWriter(sfd.FileName, false, new System.Text.UTF8Encoding(false)))
            {
                foreach (KeyValuePair<string, string> keypairvalues in urls) sw.WriteLine(keypairvalues.Value + " - " + keypairvalues.Key);
            }
            using (var sw = new StreamWriter(sfd.FileName.Replace(".txt", "_urlonly.txt"), false, new System.Text.UTF8Encoding(false)))
            {
                foreach (KeyValuePair<string, string> keypairvalues in urls) sw.WriteLine(keypairvalues.Value);
            }
            StaticsClass.InvokeIfRequired(this, () => CloseBox.Enabled = true);
            MessageBox.Show("Complete got urls." + Environment.NewLine + string.Format("location = \"{0}\"", sfd.FileName), "Otaku Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<Dictionary<string, string>> GetDownloadUrls(Dictionary<string, string> Values, string FetchMode = "")
        {
            if (_InfoFrm == null || _InfoFrm.IsDisposed) this.Invoke((MethodInvoker)(() => _InfoFrm = new InfoFrm())); //generate on main UI thread
            var Dictionary = new Dictionary<string, string>();
            StaticsClass.InvokeIfRequired(this, () =>
            {
                _InfoFrm.Show();
                _InfoFrm.BringToFront();
            });
            foreach (var keyValPair in Values)
            {
                var episodeName = GetSafeFilename(keyValPair.Key);
                try
                {
                    StaticsClass.InvokeIfRequired(this, () =>
                    {
                        _InfoFrm.textBox1.Text = $"{FetchMode}: " + episodeName;
                        _InfoFrm.textBox1.Refresh();
                    });
                }
                catch (ObjectDisposedException)
                {
                    StaticsClass.InvokeIfRequired(this, () => { _InfoFrm.Dispose(); _InfoFrm = null; });
                    return Dictionary;
                }
                var episodeUrl = keyValPair.Value;
                var safeAnimeName = GetSafeFilename(AnimeName.Text);
                string redirectorLink;
                if (VariablesClass.MasterURL == VariablesClass.KissLewdURL)
                {
                    var animeurlname = _phantomObject.Url.Substring(_phantomObject.Url.LastIndexOf("/", StringComparison.Ordinal) + 1);
                    redirectorLink = WebDriverClass.RunViaDesktop(AnimeUrl, animeurlname, episodeName, episodeUrl);
                }
                else
                {
                    redirectorLink = "";
                    try
                    {
                        redirectorLink = (await GetGoogleLink(episodeUrl)).Replace("&amp;", "&");
                    }
                    catch (Exception)
                    {

                    }
                }
                if (redirectorLink != "no")
                {
                    if (WebDriverClass.FileDoesNotExist(redirectorLink))
                    {
                        var animeurlname = _phantomObject.Url.Substring(_phantomObject.Url.LastIndexOf("/", StringComparison.Ordinal) + 1);
                        redirectorLink = WebDriverClass.RunViaDesktop(AnimeUrl, animeurlname, episodeName, episodeUrl);
                    }
                    Dictionary.Add(safeAnimeName + " - " + episodeName, redirectorLink);
                }
            }
            StaticsClass.InvokeIfRequired(this, () => { _InfoFrm.Dispose(); _InfoFrm = null; });
            return Dictionary;
        }

        private void AllCheck_CheckedChanged(object sender, EventArgs e)
        {
            var allCheck = (CheckBox)sender;
            var check = allCheck.Checked;
            foreach (EpisodeControl item in EpisodesFlowPanel.Controls) item.Checked = check;
        }
    }
}
