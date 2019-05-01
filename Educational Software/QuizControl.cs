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
        private XmlNodeList questions;
        private int current = -1;
        private int score = 0;

        public QuizControl(string xmlPath)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            this.questions = doc.DocumentElement.ChildNodes;
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
            labelProgress.Text = $"Question {current}/{questions.Count}";
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
            string inputAnswer = answersPanel.Controls.OfType<RadioButton>().FirstOrDefault(radio => radio.Checked).Text;
            string correctAnswer = question.ChildNodes.Cast<XmlNode>().First(node => node.Attributes["correct"]?.InnerXml == "true").InnerXml;
            return inputAnswer == correctAnswer;
        }

        private bool isMultiAnswerCorrect(XmlNode question)
        {
            if (question.Attributes["type"].InnerXml != "multi") return false;
            ISet<string> inputAnswers = new HashSet<string>(answersPanel.Controls.OfType<CheckBox>()
                .Where(checkbox => checkbox.Checked).Select(checkbox => checkbox.Text));
            ISet<string> correctAnswers = new HashSet<string>(question.ChildNodes.Cast<XmlNode>()
                .Where(node => node.Attributes["correct"]?.InnerXml == "true").Select(node => node.InnerXml));
            return inputAnswers.SetEquals(correctAnswers);
        }

        private void displayResults()
        {
            //TODO
        }
    }
}
