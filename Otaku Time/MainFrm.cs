using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Keys = System.Windows.Forms.Keys;

namespace Otaku_Time
{

    public partial class MainFrm : Form
    {
        private readonly DownloadingEpisodes _downloadingEpisodes;

        #region Win API Stuff

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int C_GRIP = 32;      // Grip size
        private const int C_CAPTION = 32;   // Caption bar height;
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  
                // Trap WM_NCHITTEST
                var pos = PointToClient(new Point(m.LParam.ToInt32()));
                if (pos.Y < C_CAPTION)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= ClientSize.Width - C_GRIP && pos.Y >= ClientSize.Height - C_GRIP)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        private void MoveThisform(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            else if (e.Clicks == 2)
            {
                WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            }
        }
        #endregion

        public MainFrm()
        {
            foreach (var p in Process.GetProcessesByName("PhantomJS"))
            {
                p.Kill();
            }

            InitializeComponent();
            optionStrip.Renderer = new RemStripBar();
            if (DesignMode == false)
            {
                _downloadingEpisodes = DownloadingEpisodes.GetMe();
                _downloadingEpisodes.Hide();
            }
            VersionTxt.Text += Application.ProductVersion;
            DecoratorClass.GoThroughDecorate(this);
            ProgramText.BackColor = MainFrmPanel.BackColor; //doesn't inherit control! 

        }

        #region Menu Options
        private void CloseBtnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void MaximizeBtnClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                return;
            }
            WindowState = FormWindowState.Maximized;
        }

        private void MinimizeBtnClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
       

        public void LoadMainScreen()
        {
            BuildLayout(WebDriverClass.MainMobileUpdates ());
        }

        private void BuildLayout(IEnumerable<AnimeInfoClass> animeList)
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
            var alIst = new List<Control> ();
            foreach (var animeInfo in animeList)
            {
                var animeControl = new AnimeControl(animeInfo);
                animeControl.LoadAnime += StartLoadingAnimeInformation;
                if (animeInfo.AnimeThumbnailURL.Contains(VariablesClass.MasterURL))
                {
                    animeControl.AnimeImage.Image = GetImage(animeInfo.AnimeThumbnailURL);
                }
                else
                {
                    animeControl.AnimeImage.ImageLocation = animeInfo.AnimeThumbnailURL;
                }
                alIst.Add(animeControl);
            }
            StaticsClass.InvokeIfRequired(MainFrmPanel, () => MainFrmPanel.Controls.AddRange(alIst.ToArray()));
            StaticsClass.InvokeIfRequired(MainFrmPanel, SetFlowMargin);
            StaticsClass.InvokeIfRequired(MainFrmPanel, MainFrmPanel.ResumeLayout);
        }

        private static Image GetImage(string imageLocation)
        {
            return new Bitmap(new MemoryStream(WebDriverClass.GetImageBytes(imageLocation)));
        }

        private async void SearchAnime(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        private async void StartLoadingAnimeInformation(AnimeControl ac)
        {
            LoadedAnime.AnimeName.Text = ac.AnimeName.Text;
            LoadedAnime.AnimeSynopsis.Text = ac.AnimeInfo.AnimeSeriesSynopsis;
            LoadedAnime.AnimeImage.Image = ac.AnimeImage.Image;
            LoadedAnime.AnimeUrl = $"http://{VariablesClass.MasterURL}" + ac.AnimeInfo.AnimeSeriesURL;
            LoadedAnime.LoadAnimeList(true);
            if(StaticsClass.MyAnimeListObject != null)
            {
                await LoadedAnime.GetAnimeId();
            }
            MainFrmPanel.SendToBack();
        }

        private void optionStrip_Resize(object sender, EventArgs e)
        {
            ProgramText.Margin = new Padding(optionStrip.Width / 2 - 40, 1, 0, 2);
            SetFlowMargin();
        }

        private void ShowDownloads_Click(object sender, EventArgs e)
        {
            _downloadingEpisodes.Show();
            _downloadingEpisodes.BringToFront();
        }

        private async Task AnimeSearcher()
        {
            await Task.Run(() =>
            {
                BuildLayout(WebDriverClass.GetAnimeViaMobile(AnimeSearchQuery.Text));
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
            if (_downloadingEpisodes.DownloadCount > 0)
            {
                if (MessageBox.Show("You are currently downloading, are you sure you wish you close down Otaku Time?", "Otaku Time", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            WebDriverClass.PhantomJSInstance.Quit();
            Application.Exit();
        }

        private void LoginToMalBtn_Click(object sender, EventArgs e)
        {
            if(StaticsClass.MyAnimeListObject != null)
            {
                return; //dont allow to relog in atm :)
            }
            var loginfrm = new MyAnimeListLoginFrm();
            loginfrm.LoginSuccess += () => LoginToMalBtn.Text = "Welcome, " + StaticsClass.MyAnimeListObject.Username;
            loginfrm.Show();
            loginfrm.BringToFront();
        }

        private void SetFlowMargin()
        {
            using (var ctrl = new AnimeControl())
            {
                int TotalControlSize = ctrl.Width + ctrl.Padding.Vertical + ctrl.Margin.Vertical;
                int TotalPaddingRequired = (MainFrmPanel.Width - (TotalControlSize * (int)Math.Floor((Decimal)MainFrmPanel.Width / TotalControlSize))) / 2;
                TotalPaddingRequired -= MainFrmPanel.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0;
                MainFrmPanel.Padding = new Padding(TotalPaddingRequired, 0, 0, 0);

            }
        }

    }

    internal class RemStripBar : ToolStripSystemRenderer
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e){}
    }

    internal class FlickerFreePanel : FlowLayoutPanel
    {
        public FlickerFreePanel()
        {
            DoubleBuffered = true;
        }
    }

}