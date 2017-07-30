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
            this.AnimeEpisodeList = new System.Windows.Forms.ListView();
            this.EpisodeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.WatchNowBtn = new System.Windows.Forms.Button();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.DownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeImage)).BeginInit();
            this.AnimeEpisodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.AnimeSynopsis);
            this.groupBox1.Controls.Add(this.AnimeImage);
            this.groupBox1.Controls.Add(this.AnimeName);
            this.groupBox1.Location = new System.Drawing.Point(19, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 374);
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
            this.AnimeSynopsis.Location = new System.Drawing.Point(233, 85);
            this.AnimeSynopsis.Multiline = true;
            this.AnimeSynopsis.Name = "AnimeSynopsis";
            this.AnimeSynopsis.ReadOnly = true;
            this.AnimeSynopsis.Size = new System.Drawing.Size(420, 264);
            this.AnimeSynopsis.TabIndex = 5;
            // 
            // AnimeImage
            // 
            this.AnimeImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AnimeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AnimeImage.ErrorImage = global::Otaku_Time.Properties.Resources._404;
            this.AnimeImage.ImageLocation = "";
            this.AnimeImage.Location = new System.Drawing.Point(19, 27);
            this.AnimeImage.Name = "AnimeImage";
            this.AnimeImage.Size = new System.Drawing.Size(198, 322);
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
            this.AnimeName.Location = new System.Drawing.Point(228, 36);
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
            this.AnimeEpisodes.Controls.Add(this.AnimeEpisodeList);
            this.AnimeEpisodes.Controls.Add(this.DownloadBtn);
            this.AnimeEpisodes.Controls.Add(this.WatchNowBtn);
            this.AnimeEpisodes.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimeEpisodes.ForeColor = System.Drawing.Color.White;
            this.AnimeEpisodes.Location = new System.Drawing.Point(693, 32);
            this.AnimeEpisodes.Name = "AnimeEpisodes";
            this.AnimeEpisodes.Size = new System.Drawing.Size(273, 374);
            this.AnimeEpisodes.TabIndex = 7;
            this.AnimeEpisodes.TabStop = false;
            this.AnimeEpisodes.Text = "Episodes";
            // 
            // AnimeEpisodeList
            // 
            this.AnimeEpisodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeEpisodeList.BackColor = System.Drawing.Color.White;
            this.AnimeEpisodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EpisodeColumnHeader});
            this.AnimeEpisodeList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.AnimeEpisodeList.Location = new System.Drawing.Point(6, 27);
            this.AnimeEpisodeList.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.AnimeEpisodeList.Name = "AnimeEpisodeList";
            this.AnimeEpisodeList.Size = new System.Drawing.Size(261, 298);
            this.AnimeEpisodeList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.AnimeEpisodeList.TabIndex = 8;
            this.AnimeEpisodeList.UseCompatibleStateImageBehavior = false;
            this.AnimeEpisodeList.View = System.Windows.Forms.View.Details;
            // 
            // EpisodeColumnHeader
            // 
            this.EpisodeColumnHeader.Text = "Episodes";
            this.EpisodeColumnHeader.Width = 251;
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadBtn.Location = new System.Drawing.Point(141, 331);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(126, 37);
            this.DownloadBtn.TabIndex = 1;
            this.DownloadBtn.Text = "Download";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // WatchNowBtn
            // 
            this.WatchNowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WatchNowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WatchNowBtn.Location = new System.Drawing.Point(6, 331);
            this.WatchNowBtn.Name = "WatchNowBtn";
            this.WatchNowBtn.Size = new System.Drawing.Size(126, 37);
            this.WatchNowBtn.TabIndex = 0;
            this.WatchNowBtn.Text = "Watch Now";
            this.WatchNowBtn.UseVisualStyleBackColor = true;
            this.WatchNowBtn.Click += new System.EventHandler(this.WatchNowBtn_Click);
            // 
            // CloseBox
            // 
            this.CloseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBox.Image = global::Otaku_Time.Properties.Resources.ic_close_white_24dp_1x;
            this.CloseBox.Location = new System.Drawing.Point(941, 3);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(25, 25);
            this.CloseBox.TabIndex = 9;
            this.CloseBox.TabStop = false;
            this.CloseBox.Click += new System.EventHandler(this.CloseThisPanel);
            // 
            // DownloadWorker
            // 
            this.DownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadWorker_DoWork);
            // 
            // SingleLoadedAnime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.AnimeEpisodes);
            this.Controls.Add(this.groupBox1);
            this.Name = "SingleLoadedAnime";
            this.Size = new System.Drawing.Size(974, 433);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeImage)).EndInit();
            this.AnimeEpisodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
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
        public System.Windows.Forms.ListView AnimeEpisodeList;
        private System.Windows.Forms.ColumnHeader EpisodeColumnHeader;
        private System.Windows.Forms.PictureBox CloseBox;
        private System.ComponentModel.BackgroundWorker DownloadWorker;
    }
}
