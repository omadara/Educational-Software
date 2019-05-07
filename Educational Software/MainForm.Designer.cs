namespace Educational_Software
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Lessons");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Exercises");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelCompleted = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.quizButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readingHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quizScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exerciseErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelCompleted);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.quizButton);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(753, 453);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelCompleted
            // 
            this.labelCompleted.AutoSize = true;
            this.labelCompleted.BackColor = System.Drawing.Color.Transparent;
            this.labelCompleted.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelCompleted.Location = new System.Drawing.Point(3, 9);
            this.labelCompleted.Margin = new System.Windows.Forms.Padding(3);
            this.labelCompleted.Name = "labelCompleted";
            this.labelCompleted.Size = new System.Drawing.Size(98, 13);
            this.labelCompleted.TabIndex = 1;
            this.labelCompleted.Text = "Completed 3/15";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.Cornsilk;
            this.treeView1.Location = new System.Drawing.Point(0, 28);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "LessonsNode";
            treeNode1.Text = "Lessons";
            treeNode2.Name = "ExercisesNode";
            treeNode2.Text = "Exercises";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(162, 425);
            this.treeView1.TabIndex = 0;
            this.treeView1.TabStop = false;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // quizButton
            // 
            this.quizButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.quizButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.quizButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.quizButton.Location = new System.Drawing.Point(0, 416);
            this.quizButton.Name = "quizButton";
            this.quizButton.Size = new System.Drawing.Size(587, 37);
            this.quizButton.TabIndex = 1;
            this.quizButton.Text = "Take the quiz!";
            this.quizButton.UseVisualStyleBackColor = false;
            this.quizButton.Visible = false;
            this.quizButton.Click += new System.EventHandler(this.quizButton_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(587, 410);
            this.webBrowser1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readingHistoryToolStripMenuItem,
            this.quizScoresToolStripMenuItem,
            this.exerciseErrorsToolStripMenuItem});
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.statsToolStripMenuItem.Text = "Stats";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // readingHistoryToolStripMenuItem
            // 
            this.readingHistoryToolStripMenuItem.Name = "readingHistoryToolStripMenuItem";
            this.readingHistoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readingHistoryToolStripMenuItem.Text = "Reading History";
            this.readingHistoryToolStripMenuItem.Click += new System.EventHandler(this.readingHistoryToolStripMenuItem_Click);
            // 
            // quizScoresToolStripMenuItem
            // 
            this.quizScoresToolStripMenuItem.Name = "quizScoresToolStripMenuItem";
            this.quizScoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quizScoresToolStripMenuItem.Text = "Quiz Scores";
            this.quizScoresToolStripMenuItem.Click += new System.EventHandler(this.quizScoresToolStripMenuItem_Click);
            // 
            // exerciseErrorsToolStripMenuItem
            // 
            this.exerciseErrorsToolStripMenuItem.Name = "exerciseErrorsToolStripMenuItem";
            this.exerciseErrorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exerciseErrorsToolStripMenuItem.Text = "Exercise Errors";
            this.exerciseErrorsToolStripMenuItem.Click += new System.EventHandler(this.exerciseErrorsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(753, 477);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pythonizer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button quizButton;
        private System.Windows.Forms.Label labelCompleted;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readingHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quizScoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exerciseErrorsToolStripMenuItem;
    }
}

