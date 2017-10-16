using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.PhantomJS;
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
    public partial class AreYouHumanHelpFrm : Form
    {
        private PhantomJSDriver _Driver = null;
        private string _Url = "";
        public AreYouHumanHelpFrm(PhantomJSDriver DriverToUse)
        {
            InitializeComponent();
            _Driver = DriverToUse;
            _Url = _Driver.Url;
        }

        private void AreYouHumanHelpFrm_Load(object sender, EventArgs e)
        {
            RenderScreen();
        }

        private void RenderScreen()
        {
            var img = _Driver.GetScreenshot();
            Image RenderedImg = Image.FromStream(new System.IO.MemoryStream(img.AsByteArray));
            this.Size = RenderedImg.Size;
            HelpMePictureBox.Image = RenderedImg;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (MainGrpBox.Controls.OfType<CheckBox>().Where(x => x.Checked).Count() != 2)
            {
                MessageBox.Show("Select 2 values please.", "Otaku Time");
                return;
            }
            string values = String.Join(",", MainGrpBox.Controls.OfType<CheckBox>().Where(x => x.Checked).Select(x => x.Tag));
            _Driver.ExecuteScript($"document.getElementById('answerCap').setAttribute('value','{values}')");
            _Driver.FindElementById("formVerify").Submit();
            if(_Driver.Title == "http://kissanime.ru/Special/AreYouHuman2") //user is wrong. So much for user interaction.
            {
                //restart the process.
                foreach(CheckBox Chk in MainGrpBox.Controls.Cast<CheckBox>())
                {
                    Chk.Checked = false;
                }
                _Driver.Navigate().GoToUrl(_Url);
                RenderScreen();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }


        }
    }
}
