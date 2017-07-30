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
        public string Response = "";

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
            this.ShowDialog();
            this.TopMost = true;
        }

        private void response(object sender, EventArgs e)
        {
            this.Response = ((Button)sender).Text;
            this.Close();
        }
    }
}
