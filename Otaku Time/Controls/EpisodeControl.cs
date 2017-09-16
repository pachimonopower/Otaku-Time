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
    public partial class EpisodeControl : UserControl
    {
        public delegate void UpdateMyAnimeList(MyAnimeListWrapper.MyAnimeListAnimeValuesClass Values);
        public event UpdateMyAnimeList UpdateMal;

        public bool Checked
        {
            get => EpisodeNameChk.Checked;
            set => EpisodeNameChk.Checked = value;
        }
        public override string Text
        {
            get => EpisodeNameChk.Text;
            set => EpisodeNameChk.Text = value;
        }


        public EpisodeControl()
        {
            InitializeComponent();
        }
    }
}
