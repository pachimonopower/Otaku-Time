namespace Otaku_Time
{
    partial class DownloadingEpisodes
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
            this.downloaditems = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // downloaditems
            // 
            this.downloaditems.AutoScroll = true;
            this.downloaditems.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.downloaditems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloaditems.Location = new System.Drawing.Point(0, 0);
            this.downloaditems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.downloaditems.Name = "downloaditems";
            this.downloaditems.Size = new System.Drawing.Size(963, 517);
            this.downloaditems.TabIndex = 0;
            // 
            // DownloadingEpisodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 517);
            this.Controls.Add(this.downloaditems);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DownloadingEpisodes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Episodes Currently Downloading";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadingEpisodes_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel downloaditems;
    }
}