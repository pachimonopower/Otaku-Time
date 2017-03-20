using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otaku_Time
{
    public partial class AnimeControl : UserControl
    {
        private MainFrm MainForm;
        public string AnimeSynposis = "";
        public string AnimeURL = "";

        public AnimeControl()
        {
            InitializeComponent();
        }

        private void AnimeControl_Load(object sender, EventArgs e)
        {
            AnimeName.Location = new Point(this.Width / 2,0);
            MainForm = (MainFrm)Parent.Parent;
        }

        private void SendSelfToGrandParent(object sender, EventArgs e)
        {
            MainForm.startLoadingAnimeInformation(this);
        }
    }
}
