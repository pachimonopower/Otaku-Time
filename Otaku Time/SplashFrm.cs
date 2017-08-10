using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using OpenQA.Selenium.PhantomJS;

namespace Otaku_Time
{
    public partial class SplashFrm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();


        private readonly PhantomJSDriver _phantomObject;
        private int _counter;
        private readonly MainFrm _mainFrm = new MainFrm();

        public SplashFrm()
        {
            InitializeComponent();
            DecoratorClass.GoThroughDecorate(this);
            _phantomObject = WebDriverClass.PhantomJSInstance;
        }

        private async void SplashFrm_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                _phantomObject.Navigate().GoToUrl($"http://{VariablesClass.MasterURL}/M");
                DoAuth();
            });
            await Task.Run(() =>
            {
                StaticsClass.InvokeIfRequired(WhatDoing, () => WhatDoing.Text = "Loading new titles!");
                StaticsClass.InvokeIfRequired(Progress, Progress.PerformStep);
                _mainFrm.LoadMainScreen();
            });
            StaticsClass.InvokeIfRequired(Progress, Progress.PerformStep);
            _mainFrm.Show();
            Hide();
        }

        private void DoAuth()
        {
            var titleText = "";
            switch (VariablesClass.MasterURL)
            {
                case VariablesClass.KissAnimeURL:
                    titleText = "Please wait 5 seconds";
                    break;
                case VariablesClass.KissLewdURL:
                    titleText = "Just a moment";
                    break;
                case VariablesClass.KissCartoonURL:

                    break;
            }
            while (_phantomObject.Title.Contains(titleText))
            {
                StaticsClass.InvokeIfRequired(WhatDoing, () => WhatDoing.Text = "Gaining authentication from server.");
                if (_counter != 4)
                {
                    StaticsClass.InvokeIfRequired(Progress, Progress.PerformStep);
                    _counter++;
                }
                Thread.Sleep(2000);
            }
        }

        private void MoveThisForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
