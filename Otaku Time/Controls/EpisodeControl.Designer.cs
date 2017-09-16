namespace Otaku_Time
{
    partial class EpisodeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EpisodeNameChk = new System.Windows.Forms.CheckBox();
            this.RateIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RateIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // EpisodeNameChk
            // 
            this.EpisodeNameChk.AutoSize = true;
            this.EpisodeNameChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EpisodeNameChk.ForeColor = System.Drawing.Color.White;
            this.EpisodeNameChk.Location = new System.Drawing.Point(3, 6);
            this.EpisodeNameChk.Name = "EpisodeNameChk";
            this.EpisodeNameChk.Size = new System.Drawing.Size(179, 29);
            this.EpisodeNameChk.TabIndex = 0;
            this.EpisodeNameChk.Text = "Episode Number";
            this.EpisodeNameChk.UseVisualStyleBackColor = true;
            // 
            // RateIcon
            // 
            this.RateIcon.BackgroundImage = global::Otaku_Time.Properties.Resources.keditbookmarks;
            this.RateIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RateIcon.Location = new System.Drawing.Point(323, 6);
            this.RateIcon.Name = "RateIcon";
            this.RateIcon.Size = new System.Drawing.Size(29, 29);
            this.RateIcon.TabIndex = 1;
            this.RateIcon.TabStop = false;
            // 
            // EpisodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.RateIcon);
            this.Controls.Add(this.EpisodeNameChk);
            this.Name = "EpisodeControl";
            this.Size = new System.Drawing.Size(355, 40);
            ((System.ComponentModel.ISupportInitialize)(this.RateIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EpisodeNameChk;
        public System.Windows.Forms.PictureBox RateIcon;
    }
}
