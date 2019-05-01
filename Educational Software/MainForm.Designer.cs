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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Basic Syntax");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Python Overview", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Numbers");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Strings");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lists");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tuples");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Dictionary");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Variable Types", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("If Elif Else");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("For Loop");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("While Loop");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Functions");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Control Flow", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.quizButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.labelCompleted = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(817, 475);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Cornsilk;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeView1.Location = new System.Drawing.Point(0, 28);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Basic Syntax";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Python Overview";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Numbers";
            treeNode4.Name = "Node6";
            treeNode4.Text = "Strings";
            treeNode5.Name = "Node7";
            treeNode5.Text = "Lists";
            treeNode6.Name = "Node8";
            treeNode6.Text = "Tuples";
            treeNode7.Name = "Node9";
            treeNode7.Text = "Dictionary";
            treeNode8.Name = "Node2";
            treeNode8.Text = "Variable Types";
            treeNode9.Name = "Node11";
            treeNode9.Text = "If Elif Else";
            treeNode10.Name = "Node12";
            treeNode10.Text = "For Loop";
            treeNode11.Name = "Node14";
            treeNode11.Text = "While Loop";
            treeNode12.Name = "Node15";
            treeNode12.Tag = "";
            treeNode12.Text = "Functions";
            treeNode13.Name = "Node10";
            treeNode13.Text = "Control Flow";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode8,
            treeNode13});
            this.treeView1.Size = new System.Drawing.Size(140, 447);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // quizButton
            // 
            this.quizButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.quizButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.quizButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.quizButton.Location = new System.Drawing.Point(0, 438);
            this.quizButton.Name = "quizButton";
            this.quizButton.Size = new System.Drawing.Size(673, 37);
            this.quizButton.TabIndex = 1;
            this.quizButton.Text = "Take the quiz!";
            this.quizButton.UseVisualStyleBackColor = false;
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
            this.webBrowser1.Size = new System.Drawing.Size(673, 432);
            this.webBrowser1.TabIndex = 0;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(817, 475);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Learn Python";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button quizButton;
        private System.Windows.Forms.Label labelCompleted;
    }
}

