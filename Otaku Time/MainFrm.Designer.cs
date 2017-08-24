namespace Otaku_Time
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.optionStrip = new System.Windows.Forms.ToolStrip();
            this.ProgramText = new System.Windows.Forms.ToolStripLabel();
            this.CloseFrm = new System.Windows.Forms.ToolStripButton();
            this.MaximizeFrm = new System.Windows.Forms.ToolStripButton();
            this.MinimizeFrm = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip = new System.Windows.Forms.ToolStrip();
            this.InfoBtrn = new System.Windows.Forms.ToolStripButton();
            this.AnimeSearchQuery = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ShowDownloads = new System.Windows.Forms.ToolStripButton();
            this.GoHome = new System.Windows.Forms.ToolStripButton();
            this.LoginToMalBtn = new System.Windows.Forms.ToolStripLabel();
            this.MainFrmPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AboutInfo = new System.Windows.Forms.Panel();
            this.VersionTxt = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadedAnime = new Otaku_Time.SingleLoadedAnime();
            this.optionStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.AboutInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // optionStrip
            // 
            this.optionStrip.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.optionStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.optionStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.optionStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgramText,
            this.CloseFrm,
            this.MaximizeFrm,
            this.MinimizeFrm});
            this.optionStrip.Location = new System.Drawing.Point(0, 0);
            this.optionStrip.Name = "optionStrip";
            this.optionStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.optionStrip.Size = new System.Drawing.Size(1299, 31);
            this.optionStrip.TabIndex = 0;
            this.optionStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveThisform);
            this.optionStrip.Resize += new System.EventHandler(this.optionStrip_Resize);
            // 
            // ProgramText
            // 
            this.ProgramText.AutoSize = false;
            this.ProgramText.AutoToolTip = true;
            this.ProgramText.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ProgramText.Font = new System.Drawing.Font("Tahoma", 14F);
            this.ProgramText.ForeColor = System.Drawing.Color.White;
            this.ProgramText.Margin = new System.Windows.Forms.Padding(460, 0, 0, 0);
            this.ProgramText.Name = "ProgramText";
            this.ProgramText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ProgramText.Size = new System.Drawing.Size(106, 31);
            this.ProgramText.Text = "Otaku Time";
            this.ProgramText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveThisform);
            // 
            // CloseFrm
            // 
            this.CloseFrm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseFrm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseFrm.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.CloseFrm.ForeColor = System.Drawing.Color.Black;
            this.CloseFrm.Image = global::Otaku_Time.Properties.Resources.ic_close_white_24dp_1x;
            this.CloseFrm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CloseFrm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseFrm.Name = "CloseFrm";
            this.CloseFrm.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.CloseFrm.Size = new System.Drawing.Size(28, 28);
            this.CloseFrm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CloseFrm.ToolTipText = "Close";
            this.CloseFrm.Click += new System.EventHandler(this.CloseBtnClick);
            // 
            // MaximizeFrm
            // 
            this.MaximizeFrm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MaximizeFrm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MaximizeFrm.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.MaximizeFrm.ForeColor = System.Drawing.Color.Black;
            this.MaximizeFrm.Image = global::Otaku_Time.Properties.Resources.ic_crop_square_white_24dp_1x;
            this.MaximizeFrm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MaximizeFrm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MaximizeFrm.Name = "MaximizeFrm";
            this.MaximizeFrm.Size = new System.Drawing.Size(28, 28);
            this.MaximizeFrm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MaximizeFrm.ToolTipText = "Maximise";
            this.MaximizeFrm.Click += new System.EventHandler(this.MaximizeBtnClick);
            // 
            // MinimizeFrm
            // 
            this.MinimizeFrm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MinimizeFrm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MinimizeFrm.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.MinimizeFrm.ForeColor = System.Drawing.Color.Black;
            this.MinimizeFrm.Image = global::Otaku_Time.Properties.Resources.ic_remove_white_24dp_1x;
            this.MinimizeFrm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MinimizeFrm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MinimizeFrm.Name = "MinimizeFrm";
            this.MinimizeFrm.Size = new System.Drawing.Size(28, 28);
            this.MinimizeFrm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MinimizeFrm.ToolTipText = "Minimise";
            this.MinimizeFrm.Click += new System.EventHandler(this.MinimizeBtnClick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.MenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoBtrn,
            this.AnimeSearchQuery,
            this.toolStripButton1,
            this.ShowDownloads,
            this.GoHome,
            this.LoginToMalBtn});
            this.MenuStrip.Location = new System.Drawing.Point(0, 31);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuStrip.Size = new System.Drawing.Size(1299, 33);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "toolStrip2";
            this.MenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveThisform);
            // 
            // InfoBtrn
            // 
            this.InfoBtrn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.InfoBtrn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InfoBtrn.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.InfoBtrn.ForeColor = System.Drawing.Color.Black;
            this.InfoBtrn.Image = global::Otaku_Time.Properties.Resources.ic_info_white_24dp_1x;
            this.InfoBtrn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InfoBtrn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoBtrn.Name = "InfoBtrn";
            this.InfoBtrn.Size = new System.Drawing.Size(28, 30);
            this.InfoBtrn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.InfoBtrn.ToolTipText = "About";
            this.InfoBtrn.Click += new System.EventHandler(this.InfoBtrn_Click);
            // 
            // AnimeSearchQuery
            // 
            this.AnimeSearchQuery.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AnimeSearchQuery.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.AnimeSearchQuery.Name = "AnimeSearchQuery";
            this.AnimeSearchQuery.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.AnimeSearchQuery.Size = new System.Drawing.Size(132, 27);
            this.AnimeSearchQuery.Visible = false;
            this.AnimeSearchQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchAnime);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.toolStripButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton1.Image = global::Otaku_Time.Properties.Resources.ic_search_white_24dp_1x;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 30);
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = "Search";
            this.toolStripButton1.Click += new System.EventHandler(this.ShowSearch_Click);
            // 
            // ShowDownloads
            // 
            this.ShowDownloads.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ShowDownloads.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShowDownloads.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.ShowDownloads.ForeColor = System.Drawing.Color.Black;
            this.ShowDownloads.Image = global::Otaku_Time.Properties.Resources.ic_folder_white_24dp_1x;
            this.ShowDownloads.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowDownloads.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowDownloads.Name = "ShowDownloads";
            this.ShowDownloads.Size = new System.Drawing.Size(28, 30);
            this.ShowDownloads.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ShowDownloads.ToolTipText = "Downloads";
            this.ShowDownloads.Click += new System.EventHandler(this.ShowDownloads_Click);
            // 
            // GoHome
            // 
            this.GoHome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.GoHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GoHome.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.GoHome.ForeColor = System.Drawing.Color.Black;
            this.GoHome.Image = global::Otaku_Time.Properties.Resources.ic_home_white_24dp_1x;
            this.GoHome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GoHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GoHome.Name = "GoHome";
            this.GoHome.Size = new System.Drawing.Size(28, 30);
            this.GoHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GoHome.ToolTipText = "Home";
            this.GoHome.Click += new System.EventHandler(this.GoHome_Click);
            // 
            // LoginToMalBtn
            // 
            this.LoginToMalBtn.ActiveLinkColor = System.Drawing.Color.White;
            this.LoginToMalBtn.ForeColor = System.Drawing.Color.White;
            this.LoginToMalBtn.Name = "LoginToMalBtn";
            this.LoginToMalBtn.Size = new System.Drawing.Size(155, 30);
            this.LoginToMalBtn.Text = "Login To MyAnimeList";
            this.LoginToMalBtn.Click += new System.EventHandler(this.LoginToMalBtn_Click);
            // 
            // MainFrmPanel
            // 
            this.MainFrmPanel.AutoScroll = true;
            this.MainFrmPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.MainFrmPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFrmPanel.Location = new System.Drawing.Point(0, 64);
            this.MainFrmPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainFrmPanel.Name = "MainFrmPanel";
            this.MainFrmPanel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MainFrmPanel.Size = new System.Drawing.Size(1299, 545);
            this.MainFrmPanel.TabIndex = 2;
            // 
            // AboutInfo
            // 
            this.AboutInfo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.AboutInfo.Controls.Add(this.VersionTxt);
            this.AboutInfo.Controls.Add(this.textBox1);
            this.AboutInfo.Controls.Add(this.label1);
            this.AboutInfo.Controls.Add(this.pictureBox2);
            this.AboutInfo.Controls.Add(this.pictureBox1);
            this.AboutInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutInfo.Location = new System.Drawing.Point(0, 64);
            this.AboutInfo.Margin = new System.Windows.Forms.Padding(4);
            this.AboutInfo.Name = "AboutInfo";
            this.AboutInfo.Size = new System.Drawing.Size(1299, 545);
            this.AboutInfo.TabIndex = 4;
            // 
            // VersionTxt
            // 
            this.VersionTxt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.VersionTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VersionTxt.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionTxt.ForeColor = System.Drawing.Color.White;
            this.VersionTxt.Location = new System.Drawing.Point(384, 487);
            this.VersionTxt.Margin = new System.Windows.Forms.Padding(4);
            this.VersionTxt.Name = "VersionTxt";
            this.VersionTxt.ReadOnly = true;
            this.VersionTxt.Size = new System.Drawing.Size(520, 31);
            this.VersionTxt.TabIndex = 4;
            this.VersionTxt.Text = "You\'re using Otaku Time Version: ";
            this.VersionTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(384, 132);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(531, 194);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(405, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thanks for using Otaku Time!";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Otaku_Time.Properties.Resources.yoshino;
            this.pictureBox2.Location = new System.Drawing.Point(0, 132);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(376, 404);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Otaku_Time.Properties.Resources.renge;
            this.pictureBox1.Location = new System.Drawing.Point(923, 132);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 404);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoadedAnime
            // 
            this.LoadedAnime.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.LoadedAnime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadedAnime.Location = new System.Drawing.Point(0, 64);
            this.LoadedAnime.Margin = new System.Windows.Forms.Padding(0);
            this.LoadedAnime.Name = "LoadedAnime";
            this.LoadedAnime.Size = new System.Drawing.Size(1299, 545);
            this.LoadedAnime.TabIndex = 4;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1299, 609);
            this.Controls.Add(this.MainFrmPanel);
            this.Controls.Add(this.LoadedAnime);
            this.Controls.Add(this.AboutInfo);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.optionStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFrm";
            this.ShowIcon = false;
            this.Text = "Otaku Time";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.optionStrip.ResumeLayout(false);
            this.optionStrip.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.AboutInfo.ResumeLayout(false);
            this.AboutInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip optionStrip;
        private System.Windows.Forms.ToolStrip MenuStrip;
        private System.Windows.Forms.ToolStripButton MinimizeFrm;
        private System.Windows.Forms.ToolStripButton CloseFrm;
        private System.Windows.Forms.ToolStripButton MaximizeFrm;
        private System.Windows.Forms.ToolStripTextBox AnimeSearchQuery;
        private System.Windows.Forms.ToolStripButton InfoBtrn;
        private System.Windows.Forms.ToolStripButton ShowDownloads;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripButton GoHome;
        public System.Windows.Forms.FlowLayoutPanel MainFrmPanel;
        private SingleLoadedAnime LoadedAnime;
        private System.Windows.Forms.Panel AboutInfo;
        private System.Windows.Forms.TextBox VersionTxt;
        private System.Windows.Forms.ToolStripLabel ProgramText;
        private System.Windows.Forms.ToolStripLabel LoginToMalBtn;
    }
}

