namespace Otaku_Time
{
    partial class RateAnimeControl
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
            this.StatusLbl = new System.Windows.Forms.Label();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.StatusCombo = new System.Windows.Forms.ComboBox();
            this.ScoreNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.StartedLbl = new System.Windows.Forms.Label();
            this.FinishedLbl = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.PriorityUpDown = new System.Windows.Forms.NumericUpDown();
            this.PriorityLbl = new System.Windows.Forms.Label();
            this.CommentsLbl = new System.Windows.Forms.Label();
            this.CommentsTxt = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.ForeColor = System.Drawing.Color.White;
            this.StatusLbl.Location = new System.Drawing.Point(17, 26);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(56, 17);
            this.StatusLbl.TabIndex = 0;
            this.StatusLbl.Text = "Status: ";
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.ForeColor = System.Drawing.Color.White;
            this.ScoreLbl.Location = new System.Drawing.Point(20, 69);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(53, 17);
            this.ScoreLbl.TabIndex = 2;
            this.ScoreLbl.Text = "Score: ";
            // 
            // StatusCombo
            // 
            this.StatusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCombo.FormattingEnabled = true;
            this.StatusCombo.Items.AddRange(new object[] {
            " Watching",
            "Completed",
            "OnHold",
            "Dropped",
            "PlanToWatch"});
            this.StatusCombo.Location = new System.Drawing.Point(79, 24);
            this.StatusCombo.Name = "StatusCombo";
            this.StatusCombo.Size = new System.Drawing.Size(187, 24);
            this.StatusCombo.TabIndex = 4;
            // 
            // ScoreNumericUpDown
            // 
            this.ScoreNumericUpDown.Location = new System.Drawing.Point(82, 67);
            this.ScoreNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ScoreNumericUpDown.Name = "ScoreNumericUpDown";
            this.ScoreNumericUpDown.Size = new System.Drawing.Size(53, 22);
            this.ScoreNumericUpDown.TabIndex = 5;
            this.ScoreNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(79, 107);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // StartedLbl
            // 
            this.StartedLbl.AutoSize = true;
            this.StartedLbl.ForeColor = System.Drawing.Color.White;
            this.StartedLbl.Location = new System.Drawing.Point(11, 110);
            this.StartedLbl.Name = "StartedLbl";
            this.StartedLbl.Size = new System.Drawing.Size(62, 17);
            this.StartedLbl.TabIndex = 7;
            this.StartedLbl.Text = "Started: ";
            // 
            // FinishedLbl
            // 
            this.FinishedLbl.AutoSize = true;
            this.FinishedLbl.ForeColor = System.Drawing.Color.White;
            this.FinishedLbl.Location = new System.Drawing.Point(8, 148);
            this.FinishedLbl.Name = "FinishedLbl";
            this.FinishedLbl.Size = new System.Drawing.Size(65, 17);
            this.FinishedLbl.TabIndex = 9;
            this.FinishedLbl.Text = "Finished:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(79, 146);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(187, 22);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // PriorityUpDown
            // 
            this.PriorityUpDown.Location = new System.Drawing.Point(79, 187);
            this.PriorityUpDown.Name = "PriorityUpDown";
            this.PriorityUpDown.Size = new System.Drawing.Size(53, 22);
            this.PriorityUpDown.TabIndex = 11;
            // 
            // PriorityLbl
            // 
            this.PriorityLbl.AutoSize = true;
            this.PriorityLbl.ForeColor = System.Drawing.Color.White;
            this.PriorityLbl.Location = new System.Drawing.Point(13, 189);
            this.PriorityLbl.Name = "PriorityLbl";
            this.PriorityLbl.Size = new System.Drawing.Size(60, 17);
            this.PriorityLbl.TabIndex = 10;
            this.PriorityLbl.Text = "Priority: ";
            // 
            // CommentsLbl
            // 
            this.CommentsLbl.AutoSize = true;
            this.CommentsLbl.ForeColor = System.Drawing.Color.White;
            this.CommentsLbl.Location = new System.Drawing.Point(8, 238);
            this.CommentsLbl.Name = "CommentsLbl";
            this.CommentsLbl.Size = new System.Drawing.Size(82, 17);
            this.CommentsLbl.TabIndex = 12;
            this.CommentsLbl.Text = "Comments: ";
            // 
            // CommentsTxt
            // 
            this.CommentsTxt.Location = new System.Drawing.Point(11, 258);
            this.CommentsTxt.Multiline = true;
            this.CommentsTxt.Name = "CommentsTxt";
            this.CommentsTxt.Size = new System.Drawing.Size(255, 79);
            this.CommentsTxt.TabIndex = 13;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(105, 346);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 36);
            this.SaveBtn.TabIndex = 14;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // RateAnimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CommentsTxt);
            this.Controls.Add(this.CommentsLbl);
            this.Controls.Add(this.PriorityUpDown);
            this.Controls.Add(this.PriorityLbl);
            this.Controls.Add(this.FinishedLbl);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.StartedLbl);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ScoreNumericUpDown);
            this.Controls.Add(this.StatusCombo);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.StatusLbl);
            this.Name = "RateAnimeControl";
            this.Size = new System.Drawing.Size(284, 395);
            ((System.ComponentModel.ISupportInitialize)(this.ScoreNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.ComboBox StatusCombo;
        private System.Windows.Forms.NumericUpDown ScoreNumericUpDown;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label StartedLbl;
        private System.Windows.Forms.Label FinishedLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.NumericUpDown PriorityUpDown;
        private System.Windows.Forms.Label PriorityLbl;
        private System.Windows.Forms.Label CommentsLbl;
        private System.Windows.Forms.TextBox CommentsTxt;
        private System.Windows.Forms.Button SaveBtn;
    }
}
