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
        private static string Select_lesson_sql = "SELECT title from lessons where status ='{0}';";
        private static string Select_exercise_sql = "SELECT title from exercises where status ='{0}';";
        private static string update_sql = "INSERT INTO {0}(title,status) " +
            "values('{2}','{1}') " +
            "ON CONFLICT(title) "+
            "DO UPDATE SET status='{1}'" +
            "WHERE status!='"+STATUS.COMPLETED+"';";
        private static string insert_mistake_sql = "INSERT INTO mistakes(exercise,error_type_timestamp) values ('{0}','{1}',datetime(now));";

        private enum STATUS { UNREAD,READ, COMPLETED};
        private enum ERROR_TYPE { LogicalError , SyntaxError, UnknownError }

        internal static void initialize()
        {
            if (!System.IO.File.Exists(filename))
                CreateDatabase();
            else
            {
                con = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
                con.Open();
            }
        }

        internal static void CreateDatabase()
        {
            SQLiteConnection.CreateFile(filename);
            con = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            con.Open();
            string sql1 = "CREATE TABLE IF NOT EXISTS  lessons(title TEXT PRIMARY KEY,status NUMBER,prim);";
            string sql2 = "CREATE TABLE IF NOT EXISTS  exercises(title TEXT PRIMARY KEY,status NUMBER);";
            string sql3 = "CREATE TABLE IF NOT EXISTS  mistakes(exercise TEXT,error_type NUMBER, timestamp NUMBER, FOREIGN KEY(exercise) REFERENCES exercise(title));";
            using (SQLiteCommand command = new SQLiteCommand(sql1 + sql2 + sql3, con))
                command.ExecuteNonQuery();
        }

        internal static int getCompletedLessonsCount()
        {
            return getCompletedLessonsNames().Count();
        }

        internal static int getCompletedExercisesCount()
        {
            return getCompletedExercisesNames().Count();
        }

        internal static int getTotalLessons()
        {
            return 15; //STUB
        }

        internal static IEnumerable<string> getCompletedLessonsNames()
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(Select_lesson_sql,STATUS.COMPLETED), con);
            List<string> completedLessons = new List<string>();
            foreach(IDataRecord data in com.ExecuteReader())
            {
                completedLessons.Add(data.GetString(0));

            }
            return completedLessons;
        }

        internal static IEnumerable<string> getCompletedExercisesNames()
        {
            return new string[] { "Fibonacci Numbers" }; //STUB
        }

        internal static IEnumerable<string> getReadLessonsNames()
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(Select_lesson_sql, STATUS.READ), con);
            List<string> readLessons = new List<string>();
            foreach (IDataRecord data in com.ExecuteReader())
            {
               readLessons.Add(data.GetString(0));
            }
            return readLessons;
        }

        internal static void insertLessonIfNew(string lessonName)
        {
            //STUB
        }

        internal static void markLessonAsRead(string title)
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(update_sql, "lessons", STATUS.READ, title), con);
            com.ExecuteNonQuery();
        }

        internal static void markLessonAsCompleted(string title)
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(update_sql, "lessons", STATUS.COMPLETED, title), con);
            com.ExecuteNonQuery();
        }

        internal static void markExerciseAsCompleted(string name)
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(update_sql, "exercises", STATUS.COMPLETED, name), con);
            com.ExecuteNonQuery();
        }

        internal static void insertExerciseIfNew(string exerciseName)
        {
            //STUB
        }

        internal static void recordExerciseLogicalError(string name)
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(insert_mistake_sql,name,ERROR_TYPE.LogicalError), con);
            com.ExecuteNonQuery();
        }

        internal static void recordExerciseSyntaxError(string name)
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(insert_mistake_sql, name, ERROR_TYPE.SyntaxError), con);
            com.ExecuteNonQuery();
        }

        internal static void recordExerciseUnknownError(string name)
        {
            SQLiteCommand com = new SQLiteCommand(String.Format(insert_mistake_sql, name, ERROR_TYPE.UnknownError), con);
            com.ExecuteNonQuery();
        }

        internal static IEnumerable<string> getStartedExercisesNames()
        {
            return new string[] { }; //STUB
        }

        internal static void markExerciseAsStarted(string text)
        {
            //STUB
        }
    }
}
