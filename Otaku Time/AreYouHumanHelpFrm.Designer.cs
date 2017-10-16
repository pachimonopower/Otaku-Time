namespace Otaku_Time
{
    partial class AreYouHumanHelpFrm
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
            this.HelpMePictureBox = new System.Windows.Forms.PictureBox();
            this.MainGrpBox = new System.Windows.Forms.GroupBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.HelpMePictureBox)).BeginInit();
            this.MainGrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelpMePictureBox
            // 
            this.HelpMePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpMePictureBox.Location = new System.Drawing.Point(0, 0);
            this.HelpMePictureBox.Name = "HelpMePictureBox";
            this.HelpMePictureBox.Size = new System.Drawing.Size(431, 723);
            this.HelpMePictureBox.TabIndex = 0;
            this.HelpMePictureBox.TabStop = false;
            // 
            // MainGrpBox
            // 
            this.MainGrpBox.Controls.Add(this.SubmitBtn);
            this.MainGrpBox.Controls.Add(this.checkBox4);
            this.MainGrpBox.Controls.Add(this.checkBox3);
            this.MainGrpBox.Controls.Add(this.checkBox2);
            this.MainGrpBox.Controls.Add(this.checkBox1);
            this.MainGrpBox.Location = new System.Drawing.Point(12, 12);
            this.MainGrpBox.Name = "MainGrpBox";
            this.MainGrpBox.Size = new System.Drawing.Size(193, 123);
            this.MainGrpBox.TabIndex = 1;
            this.MainGrpBox.TabStop = false;
            this.MainGrpBox.Text = "Select Image Numbers";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(50, 64);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(86, 36);
            this.SubmitBtn.TabIndex = 4;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(138, 31);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(38, 21);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Tag = "3";
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(50, 31);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(38, 21);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "1";
            this.checkBox3.Text = "2";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(94, 31);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(38, 21);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "2";
            this.checkBox2.Text = "3";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(38, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Tag = "0";
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AreYouHumanHelpFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 723);
            this.Controls.Add(this.MainGrpBox);
            this.Controls.Add(this.HelpMePictureBox);
            this.Name = "AreYouHumanHelpFrm";
            this.ShowIcon = false;
            this.Text = "Help Me Solve This!";
            this.Load += new System.EventHandler(this.AreYouHumanHelpFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HelpMePictureBox)).EndInit();
            this.MainGrpBox.ResumeLayout(false);
            this.MainGrpBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox HelpMePictureBox;
        private System.Windows.Forms.GroupBox MainGrpBox;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}