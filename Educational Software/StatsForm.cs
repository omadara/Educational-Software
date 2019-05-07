using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educational_Software
{
    public partial class StatsForm : Form
    {
        public enum StatsType{ ReadingHistory, QuizScores, ExerciseErrors}
        private StatsType type;

        public StatsForm(StatsType type) {
            this.type = type;
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats() {
            if (type == StatsType.ReadingHistory)
                loadReadingHistory();
            else if (type == StatsType.QuizScores)
                loadQuizScores();
            else if (type == StatsType.ExerciseErrors)
                loadExerciseErrors();
        }

        private void loadReadingHistory() {
            gridView.Columns.Add("Date", "Date");
            gridView.Columns.Add("Lesson", "Lesson");
            SQLiteDataReader data =  Database.getLessonReadings();
            while(data.Read()) {
                gridView.Rows.Add(data.GetDateTime(1), data.GetString(0));
            }
        }

        private void loadQuizScores() {
            gridView.Columns.Add("Date", "Date");
            gridView.Columns.Add("Lesson", "Lesson");
            gridView.Columns.Add("Correct", "Correct Answers");
            gridView.Columns.Add("Total", "Quiz Questions");
            SQLiteDataReader data = Database.getQuizScores();
            while (data.Read()) {
                gridView.Rows.Add(data.GetDateTime(0), data.GetString(1), data.GetInt32(2), data.GetInt32(3));
            }
        }

        private void loadExerciseErrors() {
            gridView.Columns.Add("Date", "Date");
            gridView.Columns.Add("Exercise", "Exercise");
            gridView.Columns.Add("Error", "Error");
            SQLiteDataReader data = Database.getExerciseErrors();
            while (data.Read()) {
                gridView.Rows.Add(data.GetDateTime(0), data.GetString(1), Database.errorTypeTolabel(data.GetInt32(2)));
            }
        }

    }
}
