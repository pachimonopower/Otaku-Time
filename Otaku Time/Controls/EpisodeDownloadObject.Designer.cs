namespace Otaku_Time
{
    partial class EpisodeDownloadObject
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
            this.visibleName = new System.Windows.Forms.Label();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.abort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // visibleName
            // 
            this.visibleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visibleName.AutoSize = true;
            this.visibleName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visibleName.ForeColor = System.Drawing.Color.White;
            this.visibleName.Location = new System.Drawing.Point(4, 7);
            this.visibleName.Name = "visibleName";
            this.visibleName.Size = new System.Drawing.Size(51, 19);
            this.visibleName.TabIndex = 0;
            this.visibleName.Text = "label1";
            // 
            // PB
            // 
            this.PB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PB.Location = new System.Drawing.Point(147, 3);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(247, 26);
            this.PB.TabIndex = 1;
            // 
            // abort
            // 
            this.abort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.abort.Location = new System.Drawing.Point(400, 3);
            this.abort.Name = "abort";
            this.abort.Size = new System.Drawing.Size(55, 26);
            this.abort.TabIndex = 2;
            this.abort.Text = "Stop";
            this.abort.UseVisualStyleBackColor = true;
            this.abort.Click += new System.EventHandler(this.abort_Click);
            // 
            // EpisodeDownloadObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.abort);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.visibleName);
            this.Name = "EpisodeDownloadObject";
            this.Size = new System.Drawing.Size(458, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label visibleName;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Button abort;
    }
}
