using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Educational_Software
{
    public partial class MainForm : Form
    {
        private QuizControl quiz;

        public MainForm()
        {
            InitializeComponent();
            Utils.fixEmulatedIEVersion();
        }

        private string getSelectedFilePath()
        {
            string filePath = Path.GetFullPath(@"..\..\course\" + treeView1.SelectedNode.FullPath);
            if (treeView1.SelectedNode.Parent == null)
                filePath += "\\" + treeView1.SelectedNode.FullPath;
            return filePath;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string filePath = getSelectedFilePath() + ".html";
            webBrowser1.Navigate("file://" + filePath);
            webBrowser1.Show();
            quizButton.Show();
            if (quiz != null) quiz.Dispose();
        }

        private void quizButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Hide();
            quizButton.Hide();
            string filePath = getSelectedFilePath() + ".xml";
            quiz = new QuizControl(filePath);
            splitContainer1.Panel2.Controls.Add(quiz);
        }
    }
}
