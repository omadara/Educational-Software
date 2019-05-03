using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Educational_Software
{
    static class Database
    {
        private static SQLiteConnection con;
        private static string filename = "db.sqlite";

        internal static void initialize()
        {
            if (!System.IO.File.Exists(filename))
                SQLiteConnection.CreateFile(filename);
            con = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            con.Open();
            string sql1 = "CREATE TABLE IF NOT EXISTS  lessons(title TEXT,times_visited INT);";
            string sql2 = "CREATE TABLE IF NOT EXISTS  student_results(question_title TEXT,answered_correctly BOOLEAN,timestamp DATETIME);";
            using (SQLiteCommand command = new SQLiteCommand(sql1 + sql2, con))
                command.ExecuteNonQuery();
        }

        internal static int getCompletedLessonsCount()
        {
            return getCompletedLessonsNames().Count();
        }

        internal static int getTotalLessons()
        {
            return 15; //STUB
        }

        internal static IEnumerable<string> getCompletedLessonsNames()
        {
            return new string[] {"Python Overview", "Basic Syntax"}; //STUB
        }

        internal static IEnumerable<string> getReadLessonsNames()
        {
            return new string[] { "Variable Types", "Numbers" }; //STUB
        }

        internal static void markLessonAsRead(string title)
        {
            //STUB
        }

        internal static void markLessonAsCompleted(string title)
        {
            //STUB
        }

        internal static void markExerciseAsCompleted(string name)
        {
            //STUB
        }

        internal static void recordExerciseLogicalError(string name)
        {
            //STUB
        }

        internal static void recordExerciseSyntaxError(string name)
        {
            //STUB
        }

        internal static void recordExerciseUnknownError(string name)
        {
            //STUB
        }

        //TODO Add_lesson,Update_lesson,Add_student_result
    }
}
