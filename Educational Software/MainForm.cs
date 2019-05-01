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
            treeView1.ExpandAll();
            updateCompletedLabel();
            updateTreeViewColors();
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
            if (quiz != null) quiz.Dispose();
            string filePath = getSelectedFilePath() + ".html";
            webBrowser1.Navigate("file://" + filePath);
            webBrowser1.Show();
            quizButton.Show();
            Database.markLessonAsRead(treeView1.SelectedNode.Text);
            updateTreeViewColors();
        }

        private void quizButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Hide();
            quizButton.Hide();
            string filePath = getSelectedFilePath() + ".xml";
            quiz = new QuizControl(filePath);
            splitContainer1.Panel2.Controls.Add(quiz);
        }

        private void updateCompletedLabel()
        {
            int count = Database.getCompletedLessonsCount();
            int total = Database.getTotalLessons();
            labelCompleted.Text = $"Completed {count}/{total}";
        }

        private void updateTreeViewColors()
        {
            ISet<string> completed = new HashSet<string>(Database.getCompletedLessonsNames());
            ISet<string> read = new HashSet<string>(Database.getReadLessonsNames());
            treeView1.forEachNode((TreeNode node) => {
                string lessonName = node.Text;
                if(completed.Contains(lessonName))
                    node.BackColor = Color.FromArgb(192, 255, 192); //green
                else if(read.Contains(lessonName))
                    node.BackColor = Color.FromArgb(192, 230, 255); //blue
                else
                    node.BackColor = Color.FromArgb(224, 224, 224); //gray
            });
        }
    }
}
