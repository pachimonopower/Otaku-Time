namespace Otaku_Time
{
    partial class MyAnimeListLoginFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.Base64Chk = new System.Windows.Forms.CheckBox();
            this.AuthBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Otaku_Time.Properties.Resources.logo_myanme_list;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Location = new System.Drawing.Point(127, 101);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(283, 22);
            this.UsernameTxt.TabIndex = 1;
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Location = new System.Drawing.Point(9, 104);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(81, 17);
            this.UsernameLbl.TabIndex = 2;
            this.UsernameLbl.Text = "Username: ";
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Location = new System.Drawing.Point(9, 145);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(77, 17);
            this.PasswordLbl.TabIndex = 4;
            this.PasswordLbl.Text = "Password: ";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(127, 142);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(283, 22);
            this.PasswordTxt.TabIndex = 3;
            // 
            // Base64Chk
            // 
            this.Base64Chk.AutoSize = true;
            this.Base64Chk.Location = new System.Drawing.Point(12, 186);
            this.Base64Chk.Name = "Base64Chk";
            this.Base64Chk.Size = new System.Drawing.Size(234, 21);
            this.Base64Chk.TabIndex = 5;
            this.Base64Chk.Text = "Login Using Base64 Auth Token";
            this.Base64Chk.UseVisualStyleBackColor = true;
            this.Base64Chk.CheckedChanged += new System.EventHandler(this.Base64Chk_CheckedChanged);
            // 
            // AuthBtn
            // 
            this.AuthBtn.Location = new System.Drawing.Point(127, 233);
            this.AuthBtn.Name = "AuthBtn";
            this.AuthBtn.Size = new System.Drawing.Size(169, 57);
            this.AuthBtn.TabIndex = 6;
            this.AuthBtn.Text = "Authenticate";
            this.AuthBtn.UseVisualStyleBackColor = true;
            this.AuthBtn.Click += new System.EventHandler(this.AuthBtn_Click);
            // 
            // MyAnimeListLoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 304);
            this.Controls.Add(this.AuthBtn);
            this.Controls.Add(this.Base64Chk);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.UsernameLbl);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyAnimeListLoginFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login To MAL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.CheckBox Base64Chk;
        private System.Windows.Forms.Button AuthBtn;
    }
}