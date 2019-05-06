using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Educational_Software
{
    static class Database
    {
        private static SQLiteConnection con;
        private static string filename = "db.sqlite";
        private static string Insert_lesson_sql = "INSERT OR IGNORE INTO lessons(title, status, read_times, timestamp) values ('{0}', " + (int)STATUS.UNREAD + ", 0, datetime('now'));";
        private static string Insert_exercise_sql = "INSERT OR IGNORE INTO exercises(title, status, timestamp) values ('{0}', " + (int)STATUS.UNREAD + ", datetime('now'));";
        private static string Insert_mistake_sql = "INSERT INTO mistakes(exercise, error_type, timestamp) values ('{0}', '{1}', datetime('now'));";
        private static string Insert_quiz_score_sql = "INSERT INTO quiz_scores(lesson, correct, total, timestamp) values ('{0}', {1}, {2}, datetime('now'));";
        private static string Insert_lesson_reading_sql = "INSERT INTO lesson_readings(lesson, timestamp) values ('{0}', datetime('now'));";
        private static string Select_lesson_sql = "SELECT title from lessons where status = {0};";
        private static string Select_exercise_sql = "SELECT title from exercises where status = {0};";
        private static string Update_lesson_status_sql = "UPDATE lessons SET status = {1}, timestamp = datetime('now') where title='{0}' and status != " + (int)STATUS.COMPLETED + ";";
        private static string Update_exercise_status_sql = "UPDATE exercises SET status = {1}, timestamp = datetime('now') where title='{0}' and status != " + (int)STATUS.COMPLETED + ";";
        
        private enum STATUS { UNREAD,READ, COMPLETED};
        private enum ERROR_TYPE { LogicalError , SyntaxError, UnknownError }

        internal static void initialize() {
            if (!System.IO.File.Exists(filename))
                SQLiteConnection.CreateFile(filename);
            con = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            con.Open();
            string sql1 = "CREATE TABLE IF NOT EXISTS  lessons(title TEXT PRIMARY KEY, status NUMBER, read_times NUMBER, timestamp NUMBER);";
            string sql2 = "CREATE TABLE IF NOT EXISTS  exercises(title TEXT PRIMARY KEY, status NUMBER, timestamp NUMBER);";
            string sql3 = "CREATE TABLE IF NOT EXISTS  mistakes(exercise TEXT, error_type NUMBER, timestamp NUMBER, FOREIGN KEY(exercise) REFERENCES exercises(title));";
            string sql4 = "CREATE TABLE IF NOT EXISTS  quiz_scores(lesson TEXT, correct NUMBER, total NUMBER, timestamp NUMBER, FOREIGN KEY(lesson) REFERENCES lessons(title));";
            string sql5 = "CREATE TABLE IF NOT EXISTS  lesson_readings(lesson TEXT, timestamp NUMBER, FOREIGN KEY(lesson) REFERENCES lessons(title));";
            using (SQLiteCommand command = new SQLiteCommand(sql1 + sql2 + sql3 + sql4 + sql5, con))
                command.ExecuteNonQuery();
        }

        internal static void insertLessonIfNew(string lessonName) {
            using (SQLiteCommand command = new SQLiteCommand(String.Format(Insert_lesson_sql, lessonName), con))
                command.ExecuteNonQuery();
        }

        internal static void insertExerciseIfNew(string exerciseName) {
            using (SQLiteCommand command = new SQLiteCommand(String.Format(Insert_exercise_sql, exerciseName), con))
                command.ExecuteNonQuery();
        }

        internal static int getCompletedLessonsCount() {
            return getCompletedLessonsNames().Count();
        }

        internal static int getCompletedExercisesCount() {
            return getCompletedExercisesNames().Count();
        }

        private static IEnumerable<string> getLessonNamesByStatus(STATUS status) {
            SQLiteCommand com = new SQLiteCommand(String.Format(Select_lesson_sql, (int)status), con);
            List<string> lessons = new List<string>();
            foreach (IDataRecord data in com.ExecuteReader())
                lessons.Add(data.GetString(0));
            com.Dispose();
            return lessons;
        }

        private static IEnumerable<string> getExerciseNamesByStatus(STATUS status) {
            SQLiteCommand com = new SQLiteCommand(String.Format(Select_exercise_sql, (int)status), con);
            List<string> exercises = new List<string>();
            foreach (IDataRecord data in com.ExecuteReader())
                exercises.Add(data.GetString(0));
            com.Dispose();
            return exercises;
        }

        internal static IEnumerable<string> getCompletedLessonsNames() {
            return getLessonNamesByStatus(STATUS.COMPLETED);
        }

        internal static IEnumerable<string> getReadLessonsNames() {
            return getLessonNamesByStatus(STATUS.READ);
        }

        internal static IEnumerable<string> getCompletedExercisesNames() {
            return getExerciseNamesByStatus(STATUS.COMPLETED);
        }

        internal static IEnumerable<string> getStartedExercisesNames() {
            return getExerciseNamesByStatus(STATUS.READ);
        }

        internal static void markLessonAsRead(string title) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Update_lesson_status_sql, title, (int)STATUS.READ), con))
                com.ExecuteNonQuery();
        }

        internal static void markLessonAsCompleted(string title) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Update_lesson_status_sql, title, (int)STATUS.COMPLETED), con))
                com.ExecuteNonQuery();
        }

        internal static void markExerciseAsStarted(string title) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Update_exercise_status_sql, title, (int)STATUS.READ), con))
                com.ExecuteNonQuery();
        }

        internal static void markExerciseAsCompleted(string title) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Update_exercise_status_sql, title, (int)STATUS.COMPLETED), con))
                com.ExecuteNonQuery();
        }

        internal static void recordExerciseLogicalError(string name) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Insert_mistake_sql, name, (int)ERROR_TYPE.LogicalError), con))
                com.ExecuteNonQuery();
        }

        internal static void recordExerciseSyntaxError(string name) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Insert_mistake_sql, name, (int)ERROR_TYPE.SyntaxError), con))
                com.ExecuteNonQuery();
        }

        internal static void recordExerciseUnknownError(string name) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Insert_mistake_sql, name, (int)ERROR_TYPE.UnknownError), con))
                com.ExecuteNonQuery();
        }

        internal static void scoreQuiz(string lessonName, int score, int count) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Insert_quiz_score_sql, lessonName, score, count), con))
                com.ExecuteNonQuery();
        }

        internal static void recordLessonReading(string lessonName) {
            using (SQLiteCommand com = new SQLiteCommand(String.Format(Insert_lesson_reading_sql, lessonName), con))
                com.ExecuteNonQuery();
        }
    }
}
