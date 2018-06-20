namespace Otaku_Time
{
    partial class SingleLoadedAnime
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AnimeSynopsis = new System.Windows.Forms.TextBox();
            this.AnimeImage = new System.Windows.Forms.PictureBox();
            this.AnimeName = new System.Windows.Forms.Label();
            this.AnimeEpisodes = new System.Windows.Forms.GroupBox();
            this.AllCheck = new System.Windows.Forms.CheckBox();
            this.GetUrlsBtn = new System.Windows.Forms.Button();
            this.EpisodesFlowPanel = new Otaku_Time.FlickerFreePanel();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.WatchNowBtn = new System.Windows.Forms.Button();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GetRawURL = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeImage)).BeginInit();
            this.AnimeEpisodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.AnimeSynopsis);
            this.groupBox1.Controls.Add(this.AnimeImage);
            this.groupBox1.Controls.Add(this.AnimeName);
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(912, 497);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // AnimeSynopsis
            // 
            this.AnimeSynopsis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeSynopsis.BackColor = System.Drawing.SystemColors.Highlight;
            this.AnimeSynopsis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimeSynopsis.ForeColor = System.Drawing.Color.White;
            this.AnimeSynopsis.Location = new System.Drawing.Point(311, 105);
            this.AnimeSynopsis.Margin = new System.Windows.Forms.Padding(4);
            this.AnimeSynopsis.Multiline = true;
            this.AnimeSynopsis.Name = "AnimeSynopsis";
            this.AnimeSynopsis.ReadOnly = true;
            this.AnimeSynopsis.Size = new System.Drawing.Size(586, 361);
            this.AnimeSynopsis.TabIndex = 5;
            // 
            // AnimeImage
            // 
            this.AnimeImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AnimeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AnimeImage.ErrorImage = global::Otaku_Time.Properties.Resources._404;
            this.AnimeImage.ImageLocation = "";
            this.AnimeImage.Location = new System.Drawing.Point(25, 33);
            this.AnimeImage.Margin = new System.Windows.Forms.Padding(4);
            this.AnimeImage.Name = "AnimeImage";
            this.AnimeImage.Size = new System.Drawing.Size(264, 433);
            this.AnimeImage.TabIndex = 3;
            this.AnimeImage.TabStop = false;
            // 
            // AnimeName
            // 
            this.AnimeName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeName.AutoSize = true;
            this.AnimeName.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimeName.ForeColor = System.Drawing.Color.White;
            this.AnimeName.Location = new System.Drawing.Point(304, 44);
            this.AnimeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AnimeName.Name = "AnimeName";
            this.AnimeName.Size = new System.Drawing.Size(64, 24);
            this.AnimeName.TabIndex = 4;
            this.AnimeName.Text = "label1";
            // 
            // AnimeEpisodes
            // 
            this.AnimeEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeEpisodes.Controls.Add(this.GetRawURL);
            this.AnimeEpisodes.Controls.Add(this.AllCheck);
            this.AnimeEpisodes.Controls.Add(this.GetUrlsBtn);
            this.AnimeEpisodes.Controls.Add(this.EpisodesFlowPanel);
            this.AnimeEpisodes.Controls.Add(this.DownloadBtn);
            this.AnimeEpisodes.Controls.Add(this.WatchNowBtn);
            this.AnimeEpisodes.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimeEpisodes.ForeColor = System.Drawing.Color.White;
            this.AnimeEpisodes.Location = new System.Drawing.Point(6, 28);
            this.AnimeEpisodes.Margin = new System.Windows.Forms.Padding(4);
            this.AnimeEpisodes.Name = "AnimeEpisodes";
            this.AnimeEpisodes.Padding = new System.Windows.Forms.Padding(0);
            this.AnimeEpisodes.Size = new System.Drawing.Size(363, 501);
            this.AnimeEpisodes.TabIndex = 7;
            this.AnimeEpisodes.TabStop = false;
            this.AnimeEpisodes.Text = "Episodes";
            // 
            // AllCheck
            // 
            this.AllCheck.AutoSize = true;
            this.AllCheck.Location = new System.Drawing.Point(9, 21);
            this.AllCheck.Name = "AllCheck";
            this.AllCheck.Size = new System.Drawing.Size(79, 21);
            this.AllCheck.TabIndex = 4;
            this.AllCheck.Text = "All check";
            this.AllCheck.UseVisualStyleBackColor = true;
            this.AllCheck.CheckedChanged += new System.EventHandler(this.AllCheck_CheckedChanged);
            // 
            // GetUrlsBtn
            // 
            this.GetUrlsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GetUrlsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetUrlsBtn.Location = new System.Drawing.Point(245, 449);
            this.GetUrlsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GetUrlsBtn.Name = "GetUrlsBtn";
            this.GetUrlsBtn.Size = new System.Drawing.Size(109, 46);
            this.GetUrlsBtn.TabIndex = 3;
            this.GetUrlsBtn.Text = "Get URLs";
            this.GetUrlsBtn.UseVisualStyleBackColor = true;
            this.GetUrlsBtn.Click += new System.EventHandler(this.GetDownloadUrlsClick);
            // 
            // EpisodesFlowPanel
            // 
            this.EpisodesFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EpisodesFlowPanel.AutoScroll = true;
            this.EpisodesFlowPanel.Location = new System.Drawing.Point(4, 44);
            this.EpisodesFlowPanel.Name = "EpisodesFlowPanel";
            this.EpisodesFlowPanel.Size = new System.Drawing.Size(355, 400);
            this.EpisodesFlowPanel.TabIndex = 2;
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadBtn.Location = new System.Drawing.Point(127, 450);
            this.DownloadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(109, 46);
            this.DownloadBtn.TabIndex = 1;
            this.DownloadBtn.Text = "Download";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadNow);
            // 
            // WatchNowBtn
            // 
            this.WatchNowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WatchNowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WatchNowBtn.Location = new System.Drawing.Point(9, 450);
            this.WatchNowBtn.Margin = new System.Windows.Forms.Padding(4);
            this.WatchNowBtn.Name = "WatchNowBtn";
            this.WatchNowBtn.Size = new System.Drawing.Size(109, 46);
            this.WatchNowBtn.TabIndex = 0;
            this.WatchNowBtn.Text = "Watch Now";
            this.WatchNowBtn.UseVisualStyleBackColor = true;
            this.WatchNowBtn.Click += new System.EventHandler(this.WatchNow);
            // 
            // CloseBox
            // 
            this.CloseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBox.Image = global::Otaku_Time.Properties.Resources.ic_close_white_24dp_1x;
            this.CloseBox.Location = new System.Drawing.Point(345, 0);
            this.CloseBox.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(24, 24);
            this.CloseBox.TabIndex = 9;
            this.CloseBox.TabStop = false;
            this.CloseBox.Click += new System.EventHandler(this.CloseThisPanel);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CloseBox);
            this.splitContainer1.Panel2.Controls.Add(this.AnimeEpisodes);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.splitContainer1.Size = new System.Drawing.Size(1299, 533);
            this.splitContainer1.SplitterDistance = 922;
            this.splitContainer1.TabIndex = 10;
            // 
            // GetRawURL
            // 
            this.GetRawURL.AutoSize = true;
            this.GetRawURL.Location = new System.Drawing.Point(192, 21);
            this.GetRawURL.Name = "GetRawURL";
            this.GetRawURL.Size = new System.Drawing.Size(99, 21);
            this.GetRawURL.TabIndex = 4;
            this.GetRawURL.Text = "GetRawURL";
            this.GetRawURL.UseVisualStyleBackColor = true;
            this.GetRawURL.CheckedChanged += new System.EventHandler(this.AllCheck_CheckedChanged);
            // 
            // SingleLoadedAnime
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SingleLoadedAnime";
            this.Size = new System.Drawing.Size(1299, 533);
            this.Load += new System.EventHandler(this.SingleLoadedAnime_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeImage)).EndInit();
            this.AnimeEpisodes.ResumeLayout(false);
            this.AnimeEpisodes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox AnimeEpisodes;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Button WatchNowBtn;
        public System.Windows.Forms.TextBox AnimeSynopsis;
        public System.Windows.Forms.PictureBox AnimeImage;
        public System.Windows.Forms.Label AnimeName;
        private System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FlickerFreePanel EpisodesFlowPanel;
        private System.Windows.Forms.Button GetUrlsBtn;
        private System.Windows.Forms.CheckBox AllCheck;
        private System.Windows.Forms.CheckBox GetRawURL;
    }
}
