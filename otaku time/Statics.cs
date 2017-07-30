using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace Otaku_Time
{
    public static class Statics
    {
        public const string KissAnimeURL = "kissanime.ru";
        public const string KissLewdURL = ""; // not adding this, you either know the url or you don't, filthy animal ;)
        public const string KissCartoonURL = "kisscartoon.io";
        public const string AuthDetails = "username:password";
        public static string AuthToken = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(AuthDetails));
        public static string MasterURL = KissAnimeURL;

        private static PhantomJSDriver MyPhantomObject;
        private static SplashFrm MySplashFrm;

        public static SplashFrm SplashFrm
        {
            get
            {
                if (MySplashFrm == null)
                {
                    MySplashFrm = new SplashFrm();
                }
                return MySplashFrm;
            }
        }

        public static PhantomJSDriver PhantomObject()
        {
            if (MyPhantomObject == null)
            {
                string UA = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_0_1 like Mac OS X) AppleWebKit/601.1 (KHTML, like Gecko) CriOS/53.0.2785.109 Mobile/14A403 Safari/601.1.46";
                string path = @"D:\Dropbox\My C# Projects\Otaku Time\Otaku Time\"; // used to make the designer work. If you can't access MainFrm designer change this to your phantomjs location.
                PhantomJSDriverService driverService = PhantomJSDriverService.CreateDefaultService();
                //driverService = PhantomJSDriverService.CreateDefaultService(path);
                var options = new PhantomJSOptions();
                options.AddAdditionalCapability("phantomjs.page.settings.userAgent", UA);
                driverService.HideCommandPromptWindow = true;

                MyPhantomObject = new PhantomJSDriver(driverService, options);
            }
            return MyPhantomObject;
        }

        public static string GetOpenloadLink(string openloadurl)
        {
            string val = "";
            string args = "/c .\\PhantomJS.exe .\\openload.js " + openloadurl;
            var startinfo = new ProcessStartInfo()
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Application.StartupPath,
                CreateNoWindow = true,
                Arguments = args,
                FileName = "cmd.exe",
                UseShellExecute = false
            };
            Process p = Process.Start(startinfo);            
            p.WaitForExit();
            val = p.StandardOutput.ReadToEnd().Replace("/r/n","").Replace("\\r\\n","");
            return val;
        }


        public static void DecorateControl(Control Control)
        {
            Color C = GetColor();
            Control.BackColor = C;

        }

        public static Color GetColor()
        {
            switch (MasterURL)
            {
                case KissAnimeURL:
                    return SystemColors.MenuHighlight;
                case KissLewdURL:
                    return Color.MediumPurple;
                case KissCartoonURL:
                    return Color.OrangeRed;
                default:
                    return Color.Red;
            }
        }

        public static void InvokeIfRequired(Control ControlToInvoke, Action RunInvoked)
        {
            if (ControlToInvoke.InvokeRequired)
            {
                ControlToInvoke.Invoke(RunInvoked);
            }
            else
            {
                RunInvoked.Invoke();
            }
        }


    }
}
