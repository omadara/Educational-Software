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
        private int current = 0;

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
            if(current == questions.Count)
            {
                //TODO display quiz results
                return;
            }
            XmlNode question = questions[current++];
            labelProgress.Text = $"Question {current}/{questions.Count}";
            labelTitle.Text = question.Attributes["title"].InnerXml;
            answersPanel.Controls.Clear();
            switch(question.Attributes["type"].InnerXml) {
                case "text":
                    textQuestion(question); break;
                case "single":
                    singleChoice(question); break;
                case "multi":
                    multiChoice(question); break;
            }
        }

        private void textQuestion(XmlNode question)
        {
            TextBox txtBox = new TextBox();
            txtBox.Size = new Size(200, 24);
            answersPanel.Controls.Add(txtBox);
        }

        private void singleChoice(XmlNode question)
        {
            foreach(XmlNode answer in question.ChildNodes)
            {
                RadioButton ans = new RadioButton();
                ans.AutoSize = true;
                ans.Text = answer.InnerXml;
                answersPanel.Controls.Add(ans);
            }
        }

        private void multiChoice(XmlNode question)
        {
            foreach (XmlNode answer in question.ChildNodes)
            {
                CheckBox ans = new CheckBox();
                ans.AutoSize = true;
                ans.Text = answer.InnerXml;
                answersPanel.Controls.Add(ans);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //TODO check question's answer
            displayNextQuestion();
        }
    }
}
