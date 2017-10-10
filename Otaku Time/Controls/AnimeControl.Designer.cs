namespace Otaku_Time
{
    partial class AnimeControl
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
            this.AnimeName = new System.Windows.Forms.Label();
            this.AnimeImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimeName
            // 
            this.AnimeName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeName.BackColor = System.Drawing.Color.Transparent;
            this.AnimeName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnimeName.ForeColor = System.Drawing.Color.White;
            this.AnimeName.Location = new System.Drawing.Point(0, 299);
            this.AnimeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AnimeName.Name = "AnimeName";
            this.AnimeName.Size = new System.Drawing.Size(263, 73);
            this.AnimeName.TabIndex = 1;
            this.AnimeName.Text = "label1";
            this.AnimeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AnimeName.Click += new System.EventHandler(this.SendSelfToGrandParent);
            // 
            // AnimeImage
            // 
            this.AnimeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AnimeImage.ErrorImage = global::Otaku_Time.Properties.Resources.loading;
            this.AnimeImage.InitialImage = global::Otaku_Time.Properties.Resources.loading;
            this.AnimeImage.Location = new System.Drawing.Point(3, 2);
            this.AnimeImage.Margin = new System.Windows.Forms.Padding(0);
            this.AnimeImage.Name = "AnimeImage";
            this.AnimeImage.Size = new System.Drawing.Size(256, 297);
            this.AnimeImage.TabIndex = 0;
            this.AnimeImage.TabStop = false;
            this.AnimeImage.Click += new System.EventHandler(this.SendSelfToGrandParent);
            // 
            // AnimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.AnimeName);
            this.Controls.Add(this.AnimeImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AnimeControl";
            this.Size = new System.Drawing.Size(263, 372);
            this.Click += new System.EventHandler(this.SendSelfToGrandParent);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimeControl_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.AnimeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox AnimeImage;
        public System.Windows.Forms.Label AnimeName;
    }
}
