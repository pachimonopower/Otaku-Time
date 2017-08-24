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
    public static class StaticsClass
    {
        public static MyAnimeListWrapper.MyAnimeListClass MyAnimeListObject = null;
        public static string GetOpenloadLink(string openloadurl)
        {
            string val = "";
            string args = "/c .\\PhantomJS.exe .\\Resources\\openload.js " + openloadurl;
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
