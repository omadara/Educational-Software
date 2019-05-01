using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Educational_Software
{
    class Database
    {
        private SQLiteConnection con;
        private string filename = "db.sqlite";
        public Database()
        {
            if (!System.IO.File.Exists(filename))
            {
                SQLiteConnection.CreateFile(filename);
            }
            con = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            con.Open();
            string sql1 = "CREATE TABLE IF NOT EXISTS  lessons(title TEXT,times_visited INT);";
            string sql2 = "CREATE TABLE IF NOT EXISTS  student_results(question_title TEXT,answered_correctly BOOLEAN,timestamp DATETIME);";
            SQLiteCommand command = new SQLiteCommand(sql1+sql2, con);
            command.ExecuteNonQuery();
        }

        //TODO Add_lesson,Update_lesson,Add_student_result
    }
}
