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
using OpenQA.Selenium.PhantomJS;

namespace Otaku_Time
{
    public partial class SplashFrm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private PhantomJSDriver PhantomObject;
        private int counter = 0;
        private MainFrm MainFrm = new MainFrm();


        public SplashFrm()
        {
            InitializeComponent();
            DecoratorClass.GoThroughDecorate(this);
            PhantomObject = WebDriverClass.GetPhantomJSInstance();
        }

        private async void SplashFrm_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                PhantomObject.Navigate().GoToUrl($"http://{VariablesClass.MasterURL}/M");
                DoAuth();
            });
            await Task.Run(() =>
            {
                StaticsClass.InvokeIfRequired(this.WhatDoing, () => this.WhatDoing.Text = "Loading new titles!");
                StaticsClass.InvokeIfRequired(this.Progress, this.Progress.PerformStep);
                MainFrm.LoadMainScreen();
            });
            StaticsClass.InvokeIfRequired(this.Progress, this.Progress.PerformStep);
            MainFrm.Show();
            this.Hide();
        }

        private void DoAuth()
        {
            string TitleText = "";
            switch(VariablesClass.MasterURL)
            {
                case VariablesClass.KissAnimeURL:
                    TitleText = "Please wait 5 seconds";
                    break;
                case VariablesClass.KissLewdURL:
                    TitleText = "Just a moment";
                    break;
                case VariablesClass.KissCartoonURL:

                    break;
            }
            if (PhantomObject.Title.Contains(TitleText))
            {
                StaticsClass.InvokeIfRequired(this.WhatDoing, () => this.WhatDoing.Text = "Gaining authentication from server.");
                if (counter != 4)
                {
                    StaticsClass.InvokeIfRequired(this.Progress, this.Progress.PerformStep);
                    counter++;
                }
                System.Threading.Thread.Sleep(2000);
                DoAuth();
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
