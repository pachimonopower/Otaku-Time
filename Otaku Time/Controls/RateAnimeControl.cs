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
    public partial class RateAnimeControl : UserControl
    {
        public delegate void _SaveRaised(RateAnimeControl RateControl, MyAnimeListWrapper.MyAnimeListAnimeValuesClass MalValues);
        public event _SaveRaised SaveRecord;

        private int _EpisodeNumber = 0;

        public RateAnimeControl()
        {
            InitializeComponent();
        }

        public RateAnimeControl(int EpisodeNumber)
        {
            InitializeComponent();
            _EpisodeNumber = EpisodeNumber;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var MalValue = new MyAnimeListWrapper.MyAnimeListAnimeValuesClass()
            {
                Status = (MyAnimeListWrapper.MyAnimeListAnimeValuesClass.StatusValues)Enum.Parse(typeof(MyAnimeListWrapper.MyAnimeListAnimeValuesClass.StatusValues), StatusCombo.Text, true),
                Score = (int)ScoreNumericUpDown.Value,
                Priority = (int)PriorityUpDown.Value,
                DateStarted = dateTimePicker1.Value,
                DateFinished = dateTimePicker2.Value,
                Comments = CommentsTxt.Text,
                Episode = _EpisodeNumber
            };
            SaveRecord(this, MalValue);
        }
    }
}
