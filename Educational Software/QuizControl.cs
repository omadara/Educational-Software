using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Educational_Software
{
    public partial class QuizControl : UserControl
    {
        private const float SUCCESS_PERCENTAGE = 0.60f;
        private readonly string lessonName;
        private readonly string[] chapterLessonNames;
        private readonly EventHandler nextLesson_Click;
        private readonly EventHandler quiz_Successful;
        private readonly XmlNodeList questions;
        private int[] prereqsCount;
        private int current;
        private int score;

        public QuizControl(string lessonName, string xmlPath, EventHandler nextLesson_Click, EventHandler quiz_Successful, string[] chapterLessonNames)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            this.questions = doc.DocumentElement.ChildNodes;
            this.lessonName = lessonName;
            this.nextLesson_Click = nextLesson_Click;
            this.quiz_Successful = quiz_Successful;
            this.chapterLessonNames = chapterLessonNames;
            reset();
        }

        private void reset()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            score = 0;
            current = -1;
            this.prereqsCount = new int[chapterLessonNames.Length];
            displayNextQuestion();
        }

        private void displayNextQuestion()
        {
            current++;
            if(current == questions.Count) {
                displayResults();
                return;
            }
            XmlNode question = questions[current];
            labelProgress.Text = $"Question {current+1}/{questions.Count}";
            labelTitle.Text = question.Attributes["title"].InnerXml;
            answersPanel.Controls.Clear();
            if (question.Attributes["type"].InnerXml == "text") {
                TextBox txtBox = new TextBox();
                txtBox.Size = new Size(200, 24);
                answersPanel.Controls.Add(txtBox);
            } else if (question.Attributes["type"].InnerXml == "single") {
                foreach (XmlNode answer in question.ChildNodes) {
                    RadioButton ans = new RadioButton();
                    ans.AutoSize = true;
                    ans.Text = answer.InnerXml;
                    answersPanel.Controls.Add(ans);
                }
            } else if (question.Attributes["type"].InnerXml == "multi") {
                foreach (XmlNode answer in question.ChildNodes) {
                    CheckBox ans = new CheckBox();
                    ans.AutoSize = true;
                    ans.Text = answer.InnerXml;
                    answersPanel.Controls.Add(ans);
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            XmlNode question = questions[current];
            if (isTextAnswerCorrect(question) 
                || isSingleAnswerCorrect(question)
                || isMultiAnswerCorrect(question)) {
                score++;
            } else {
                gotWrongAnswer(question);
            }
            displayNextQuestion();
        }

        private bool isTextAnswerCorrect(XmlNode question)
        {
            if (question.Attributes["type"].InnerXml != "text") return false;
            string inputText = answersPanel.Controls[0].Text;
            string correctAnswer = question.FirstChild.InnerXml;
            return inputText == correctAnswer;
        }

        private bool isSingleAnswerCorrect(XmlNode question)
        {
            if (question.Attributes["type"].InnerXml != "single") return false;
            string inputAnswer = answersPanel.Controls.OfType<RadioButton>().FirstOrDefault(radio => radio.Checked)?.Text;
            string correctAnswer = question.ChildNodes.Cast<XmlNode>().First(node => node.Attributes["correct"]?.InnerXml == "true").InnerXml;
            return inputAnswer == correctAnswer;
        }

        private bool isMultiAnswerCorrect(XmlNode question)
        {
            if (question.Attributes["type"].InnerXml != "multi") return false;
            ISet<string> inputAnswers = new HashSet<string>(answersPanel.Controls.OfType<CheckBox>()
                .Where(checkbox => checkbox.Checked)?.Select(checkbox => checkbox.Text));
            ISet<string> correctAnswers = new HashSet<string>(question.ChildNodes.Cast<XmlNode>()
                .Where(node => node.Attributes["correct"]?.InnerXml == "true")?.Select(node => node.InnerXml));
            return inputAnswers.SetEquals(correctAnswers);
        }

        private void gotWrongAnswer(XmlNode question)
        {
            string pStr = question.Attributes["prereq"]?.Value;
            if (pStr == null) return;
            int[] prereqs = pStr.Split('|').Select(s => int.Parse(s)).ToArray();
            foreach (int p in prereqs)
                prereqsCount[p]++;
        }

        private void displayResults()
        {
            flowLayoutPanel1.Hide();
            resultsPanel.Show();
            float scoreRatio = (float)score / questions.Count;
            label1.Text = $"You got {score} out of {questions.Count} questions correct" + (scoreRatio == 1 ? "!!" : ".");
            Database.scoreQuiz(lessonName, score, questions.Count);
            if (scoreRatio >= SUCCESS_PERCENTAGE) {
                quiz_Successful(null, null);
                nextButton.Show();
                nextButton.Click += nextLesson_Click;
                if (scoreRatio != 1) {
                    againButton.Show();
                    againButton.Click += tryAgain_Click;
                }
            } else {
                labelSuccess.ForeColor = Color.Firebrick;
                labelSuccess.Text = "Ops...";
                label1.Text += $"\nAnswer at least {Math.Ceiling(SUCCESS_PERCENTAGE*questions.Count)} questions correctly to pass.";
                againButton.Show();
                againButton.Click += tryAgain_Click;
                displayRecommendationsIfExists();
            }
        }

        private void displayRecommendationsIfExists()
        {
            int max = prereqsCount.Max();
            if (max == 0) return; //no recommendations from prereqs
            int argMax = Array.IndexOf(prereqsCount, max);
            labelRec.Show();
            labelRec.Text = $"Please read: '{chapterLessonNames[argMax]}' and try again.";
        }

        private void tryAgain_Click(object sender, EventArgs e)
        {
            resultsPanel.Dispose();
            flowLayoutPanel1.Dispose();
            reset();
        }
    }
}
