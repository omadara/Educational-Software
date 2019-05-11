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
            webBrowser1.Navigate("file://" + Path.GetFullPath(@"..\..\extra\welcome.html"));
            feedTreeViewFromFileSystem();
            treeView1.ExpandAll();
            updateCompletedLabel();
            updateTreeViewColors();
        }

        private void feedTreeViewFromFileSystem()
        {
            //lessons
            foreach(string dirPath in Directory.GetDirectories(@"..\..\extra\Lessons")) {
                string chapterName = Path.GetFileName(dirPath);
                TreeNode chapter = treeView1.Nodes["LessonsNode"].Nodes.Add(chapterName);
                foreach (string filename in Directory.GetFiles(dirPath, "*.html").OrderBy(f => f)) {
                    string lessonName = Path.GetFileNameWithoutExtension(filename).Split(new char[] { '_' }, 2)[1];
                    TreeNode node = chapter.Nodes.Add(lessonName);
                    node.Tag = filename;
                    Database.insertLessonIfNew(lessonName);
                }
            }
            //exercises
            foreach(string filename in Directory.GetFiles(@"..\..\extra\Exercises", "*.py").OrderBy(f => f)) {
                if (filename.EndsWith("testing.py")) continue;
                string exerciseName = Path.GetFileNameWithoutExtension(filename);
                TreeNode node = treeView1.Nodes["ExercisesNode"].Nodes.Add(exerciseName);
                node.Tag = filename;
                Database.insertExerciseIfNew(exerciseName);
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            if (!e.Node.isLeaf()) e.Cancel = true; //can select only leafs
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (quiz != null) quiz.Dispose();
            if (exercise != null) exercise.Dispose();
            if (treeView1.SelectedNode.Parent?.Text == "Exercises") {
                exerciseSelected();
                return;
            }
            string htmlFilePath = treeView1.SelectedNode.Tag as string;
            webBrowser1.Navigate("file://" + Path.GetFullPath(htmlFilePath));
            webBrowser1.Show();
            quizButton.Show();
            Database.recordLessonReading(treeView1.SelectedNode.Text);
            updateTreeViewColors();
        }

        private void exerciseSelected()
        {
            webBrowser1.Hide();
            quizButton.Hide();
            string pyFilePath = treeView1.SelectedNode.Tag as string;
            exercise = new ExerciseControl(treeView1.SelectedNode.Text, pyFilePath, exercise_Completed);
            splitContainer1.Panel2.Controls.Add(exercise);
            Database.markExerciseAsStarted(treeView1.SelectedNode.Text);
        }

        private void quizButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Hide();
            quizButton.Hide();
            string xmlFilePath = (treeView1.SelectedNode.Tag as string).Replace(".html", ".xml");
            quiz = new QuizControl(treeView1.SelectedNode.Text, xmlFilePath, nextLesson_Click, quiz_Successful);
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
                selected = selected.Parent?.NextNode?.Nodes?[0]; //next cousin
            if(selected != null)
                treeView1.SelectedNode = selected;            
        }

        private void updateCompletedLabel()
        {
            int count = Database.getCompletedLessonsCount() + Database.getCompletedExercisesCount();
            int total = treeView1.countLeafs();
            labelCompleted.Text = $"Completed {count}/{total}";
        }

        private void updateTreeViewColors()
        {
            colorizeAllTreeViewLeafs(treeView1.Nodes["LessonsNode"], Color.FromArgb(224, 224, 224)); //gray
            colorizeTreeViewLeafs(treeView1.Nodes["LessonsNode"], Database.getCompletedLessonsNames(), Color.FromArgb(192, 255, 192)); // green
            colorizeTreeViewLeafs(treeView1.Nodes["LessonsNode"], Database.getReadLessonsNames(), Color.FromArgb(192, 230, 255)); //blue
            colorizeAllTreeViewLeafs(treeView1.Nodes["ExercisesNode"], Color.FromArgb(224, 224, 224)); //gray
            colorizeTreeViewLeafs(treeView1.Nodes["ExercisesNode"], Database.getCompletedExercisesNames(), Color.FromArgb(192, 255, 192)); //green
            colorizeTreeViewLeafs(treeView1.Nodes["ExercisesNode"], Database.getStartedExercisesNames(), Color.FromArgb(192, 230, 255)); //blue
        }

        private void colorizeAllTreeViewLeafs(TreeNode root, Color color)
        {
            root.forEachNode((TreeNode node) => {
                if (node.isLeaf()) node.BackColor = color;
            });
        }

        private void colorizeTreeViewLeafs(TreeNode root, IEnumerable<string> nodeTexts, Color color)
        {
            ISet<string> nodeTextsSet = new HashSet<string>(nodeTexts);
            root.forEachNode((TreeNode node) => {
                if (node.isLeaf() && nodeTextsSet.Contains(node.Text))
                    node.BackColor = color;
            });
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            Help.ShowHelp(this, "manual.chm", HelpNavigator.TopicId, "10");
        }

        private void readingHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
            new StatsForm(StatsForm.StatsType.ReadingHistory).Show();
        }

        private void quizScoresToolStripMenuItem_Click(object sender, EventArgs e) {
            new StatsForm(StatsForm.StatsType.QuizScores).Show();
        }

        private void exerciseErrorsToolStripMenuItem_Click(object sender, EventArgs e) {
            new StatsForm(StatsForm.StatsType.ExerciseErrors).Show();
        }
    }
}
