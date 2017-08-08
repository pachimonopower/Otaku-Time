using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otaku_Time
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Count() > 0)
            {
                switch(args[0])
                {
                    case VariablesClass.KissAnimeURL:
                        VariablesClass.MasterURL = VariablesClass.KissAnimeURL;
                        break;
                    case VariablesClass.KissLewdURL:
                        VariablesClass.MasterURL = VariablesClass.KissLewdURL;
                        break;
                    case VariablesClass.KissCartoonURL:
                        VariablesClass.MasterURL = VariablesClass.KissCartoonURL;
                        break;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashFrm());
            
        }
    }
}
