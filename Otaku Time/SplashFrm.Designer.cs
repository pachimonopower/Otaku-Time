namespace Otaku_Time
{
    partial class SplashFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashFrm));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AnimeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.WhatDoing = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Otaku_Time.Properties.Resources.yoshino;
            this.pictureBox2.InitialImage = global::Otaku_Time.Properties.Resources.yoshino;
            this.pictureBox2.Location = new System.Drawing.Point(647, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(321, 378);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // AnimeName
            // 
            this.AnimeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnimeName.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimeName.ForeColor = System.Drawing.Color.White;
            this.AnimeName.Location = new System.Drawing.Point(0, 0);
            this.AnimeName.Name = "AnimeName";
            this.AnimeName.Size = new System.Drawing.Size(912, 113);
            this.AnimeName.TabIndex = 2;
            this.AnimeName.Text = "Otaku Time";
            this.AnimeName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AnimeName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveThisForm);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Loading dependancies, please wait...";
            // 
            // Progress
            // 
            this.Progress.BackColor = System.Drawing.Color.White;
            this.Progress.Location = new System.Drawing.Point(16, 448);
            this.Progress.Maximum = 50;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(359, 27);
            this.Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Progress.TabIndex = 4;
            // 
            // WhatDoing
            // 
            this.WhatDoing.AutoSize = true;
            this.WhatDoing.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatDoing.ForeColor = System.Drawing.Color.White;
            this.WhatDoing.Location = new System.Drawing.Point(12, 419);
            this.WhatDoing.Name = "WhatDoing";
            this.WhatDoing.Size = new System.Drawing.Size(0, 24);
            this.WhatDoing.TabIndex = 5;
            // 
            // SplashFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(912, 494);
            this.Controls.Add(this.WhatDoing);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnimeName);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Otaku Time";
            this.Load += new System.EventHandler(this.SplashFrm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveThisForm);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar Progress;
        public System.Windows.Forms.Label AnimeName;
        public System.Windows.Forms.Label WhatDoing;
    }
}