using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otaku_Time
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(string message, string title, string buttonOneText, string buttonTwoText)
        {
            InitializeComponent();
            this.Text = title;
            this.label1.Text = message;
            this.button1.Text = buttonOneText;
            this.button2.Text = buttonTwoText;
        }

        public void Load()
        {
            this.Show();
            this.TopMost = true;
        }

        private void response(object sender, EventArgs e)
        {
            string resp = ((Button)sender).Text;
            SingleLoadedAnime.response = resp;
            this.Close();
        }
    }
}
