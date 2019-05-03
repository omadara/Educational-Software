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
        private ExerciseControl exercise;

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
            if (treeView1.SelectedNode.Text == "Exercises") return;
            if (quiz != null) quiz.Dispose();
            if (exercise != null) exercise.Dispose();
            if (treeView1.SelectedNode.Parent?.Text == "Exercises") {
                exerciseSelected();
                return;
            }
            string filePath = getSelectedFilePath() + ".html";
            webBrowser1.Navigate("file://" + filePath);
            webBrowser1.Show();
            quizButton.Show();
            Database.markLessonAsRead(treeView1.SelectedNode.Text);
            updateTreeViewColors();
        }

        private void exerciseSelected()
        {
            webBrowser1.Hide();
            quizButton.Hide();
            string filePath = getSelectedFilePath();
            exercise = new ExerciseControl(treeView1.SelectedNode.Text, filePath + "_quiz.py", filePath + "_test.py", exercise_Completed);
            splitContainer1.Panel2.Controls.Add(exercise);
        }

        private void quizButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Hide();
            quizButton.Hide();
            string filePath = getSelectedFilePath() + ".xml";
            quiz = new QuizControl(filePath, nextLesson_Click, quiz_Successful);
            splitContainer1.Panel2.Controls.Add(quiz);
        }

        private void quiz_Successful(object sender, EventArgs e)
        {
            Database.markLessonAsCompleted(treeView1.SelectedNode.Text);
            updateCompletedLabel();
            updateTreeViewColors();
        }

        private void exercise_Completed(object sender, EventArgs e)
        {
            Database.markExerciseAsCompleted(treeView1.SelectedNode.Text);
            updateCompletedLabel();
            updateTreeViewColors();
        }

        private void nextLesson_Click(object sender, EventArgs e)
        {
            TreeNode selected = treeView1.SelectedNode;
            if (selected.Nodes.Count != 0)
                selected = treeView1.SelectedNode.Nodes[0]; //first child
            else if (selected.NextNode != null)
                selected = selected.NextNode; //next sibling
            else
                selected = selected.Parent?.NextNode; //next aunt
            if(selected != null)
                treeView1.SelectedNode = selected;            
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
                if(lessonName == "Exercises") return;
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
