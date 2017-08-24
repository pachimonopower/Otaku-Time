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
    public partial class MyAnimeListLoginFrm : Form
    {
        public delegate void LoginSuccessfulDelegate();
        public event LoginSuccessfulDelegate LoginSuccess;


        public MyAnimeListLoginFrm()
        {
            InitializeComponent();
        }

        private void Base64Chk_CheckedChanged(object sender, EventArgs e)
        {
            if(Base64Chk.Checked)
            {
                UsernameLbl.Text = "Base 64 Token: ";
                PasswordLbl.Visible = false;
                PasswordTxt.Visible = false;
            }
            else
            {
                UsernameLbl.Text = "Username: ";
                PasswordLbl.Visible = true;
                PasswordTxt.Visible = true;
            }
        }

        private async void AuthBtn_Click(object sender, EventArgs e)
        {
            var MyAnimeListObject = new MyAnimeListWrapper.MyAnimeListClass();
            bool Result = false;
            if (Base64Chk.Checked)
                Result = await MyAnimeListObject.Login(UsernameTxt.Text); // should be base64
            else
                Result = await MyAnimeListObject.Login(UsernameTxt.Text, PasswordTxt.Text); //normal login :D
            if(!Result)
            {
                MessageBox.Show("Login Failed!", "Otaku Time");
            }
            else
            {
                StaticsClass.MyAnimeListObject = MyAnimeListObject; //validated and set.
                LoginSuccess();
                this.Close();
            }
        }
    }
}
