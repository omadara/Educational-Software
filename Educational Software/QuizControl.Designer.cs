namespace Educational_Software
{
    partial class QuizControl
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
            this.labelSuccess = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.againButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.answersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDivider = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.resultsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelRec = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.resultsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelSuccess.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.labelSuccess.Location = new System.Drawing.Point(10, 10);
            this.labelSuccess.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(191, 23);
            this.labelSuccess.TabIndex = 0;
            this.labelSuccess.Text = "Congratulations!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(10, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "You answered correctly 2 out of 3 questions.";
            // 
            // nextButton
            // 
            this.nextButton.AutoSize = true;
            this.nextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nextButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.nextButton.Location = new System.Drawing.Point(10, 99);
            this.nextButton.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(106, 32);
            this.nextButton.TabIndex = 8;
            this.nextButton.Text = "Next Lesson";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Visible = false;
            // 
            // againButton
            // 
            this.againButton.AutoSize = true;
            this.againButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.againButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.againButton.Location = new System.Drawing.Point(10, 141);
            this.againButton.Margin = new System.Windows.Forms.Padding(10);
            this.againButton.Name = "againButton";
            this.againButton.Size = new System.Drawing.Size(106, 32);
            this.againButton.TabIndex = 9;
            this.againButton.Text = "Try Again";
            this.againButton.UseVisualStyleBackColor = false;
            this.againButton.Visible = false;
            // 
            // submitButton
            // 
            this.submitButton.AutoSize = true;
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.submitButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.submitButton.Location = new System.Drawing.Point(3, 76);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(106, 32);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // answersPanel
            // 
            this.answersPanel.AutoSize = true;
            this.answersPanel.BackColor = System.Drawing.Color.OldLace;
            this.answersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answersPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.answersPanel.Location = new System.Drawing.Point(3, 68);
            this.answersPanel.Name = "answersPanel";
            this.answersPanel.Size = new System.Drawing.Size(2, 2);
            this.answersPanel.TabIndex = 5;
            this.answersPanel.WrapContents = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelTitle.Location = new System.Drawing.Point(3, 46);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(206, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "This is example question text.";
            // 
            // labelDivider
            // 
            this.labelDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDivider.Location = new System.Drawing.Point(3, 41);
            this.labelDivider.Name = "labelDivider";
            this.labelDivider.Size = new System.Drawing.Size(1000, 2);
            this.labelDivider.TabIndex = 7;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelProgress.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelProgress.Location = new System.Drawing.Point(15, 15);
            this.labelProgress.Margin = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(976, 16);
            this.labelProgress.TabIndex = 3;
            this.labelProgress.Text = "Question 1/3";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.labelProgress);
            this.flowLayoutPanel1.Controls.Add(this.labelDivider);
            this.flowLayoutPanel1.Controls.Add(this.labelTitle);
            this.flowLayoutPanel1.Controls.Add(this.answersPanel);
            this.flowLayoutPanel1.Controls.Add(this.submitButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(634, 426);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // resultsPanel
            // 
            this.resultsPanel.Controls.Add(this.labelSuccess);
            this.resultsPanel.Controls.Add(this.label1);
            this.resultsPanel.Controls.Add(this.labelRec);
            this.resultsPanel.Controls.Add(this.nextButton);
            this.resultsPanel.Controls.Add(this.againButton);
            this.resultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.resultsPanel.Location = new System.Drawing.Point(0, 0);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(634, 426);
            this.resultsPanel.TabIndex = 10;
            this.resultsPanel.Visible = false;
            // 
            // labelRec
            // 
            this.labelRec.AutoSize = true;
            this.labelRec.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelRec.Location = new System.Drawing.Point(10, 71);
            this.labelRec.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.labelRec.Name = "labelRec";
            this.labelRec.Size = new System.Drawing.Size(180, 18);
            this.labelRec.TabIndex = 10;
            this.labelRec.Text = "Please read: \'Lesson 1\'";
            this.labelRec.Visible = false;
            // 
            // QuizControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.Controls.Add(this.resultsPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Name = "QuizControl";
            this.Size = new System.Drawing.Size(634, 426);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.resultsPanel.ResumeLayout(false);
            this.resultsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.FlowLayoutPanel answersPanel;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDivider;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button againButton;
        private System.Windows.Forms.FlowLayoutPanel resultsPanel;
        private System.Windows.Forms.Label labelRec;
    }
}
