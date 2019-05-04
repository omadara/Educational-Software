using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ScintillaNET;
using System.Diagnostics;

namespace Educational_Software
{
    public partial class ExerciseControl : UserControl
    {
        private readonly string name;
        private readonly EventHandler exercise_Completed;
        private readonly string tmpFilePath = Path.GetFullPath(@"..\..\extra\Exercises\program.py");
        private readonly string seperator = "# TEST CODE START";
        private readonly string testingCode;

        public ExerciseControl(string name, string pyFilePath, EventHandler exercise_Completed)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.name = name;
            this.exercise_Completed = exercise_Completed;
            editor.configureStylesForPython();

            string exerciseCode = File.ReadAllText(pyFilePath);
            string[] parts = exerciseCode.Split(new String[] { seperator }, StringSplitOptions.None);
            editor.Text = parts[0]; //show to the user the exircise code without the test code
            testingCode = parts[1]; //the testing code
            editor.highlightWord("?", Color.Red);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if(editor.Text.Contains("?")) {
                MessageBox.Show("Please remove the question marks before running your code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string codeWithTests = editor.Text + "\n" + testingCode;
            File.WriteAllText(tmpFilePath, codeWithTests, Encoding.UTF8);
            executePythonCode(tmpFilePath);
            File.Delete(tmpFilePath);
        }

        private void executePythonCode(string filePath)
        {
            using (Process p = new Process()) {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WorkingDirectory = Path.GetFullPath(@"..\..\extra\Exercises");
                p.StartInfo.FileName = "python";
                p.StartInfo.Arguments = '"' + filePath + '"'; //surround with quotes so it doesnt get split if it contains spaces
                p.Start();
                if (!p.WaitForExit(5000)) {
                    MessageBox.Show("Your little program took longer than 5 seconds to run...\nHad to kill it, sorry!", "Infinite loop detected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string outputError = p.StandardError.ReadToEnd();
                if(!string.IsNullOrEmpty(outputError)) {
                    if (outputError.Contains("SyntaxError"))
                        Database.recordExerciseSyntaxError(name);
                    else
                        Database.recordExerciseUnknownError(name);
                    outputArea.ForeColor = Color.LightCoral;
                    outputArea.Text = outputError;
                    return;
                }
                string outputWithTests = p.StandardOutput.ReadToEnd();
                if(outputWithTests.Contains("FAILED")) {
                    Database.recordExerciseLogicalError(name);
                    outputArea.ForeColor = Color.Khaki;
                    outputArea.Text = outputWithTests;
                } else {
                    exercise_Completed(null, null);
                    outputArea.ForeColor = Color.White;
                    outputArea.Text = outputWithTests;
                    MessageBox.Show("Well done!", "Exercise Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (File.Exists(tmpFilePath))
                File.Delete(tmpFilePath);
            base.OnHandleDestroyed(e);
        }


    }
}
