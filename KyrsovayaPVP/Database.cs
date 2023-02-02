using System;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace KyrsovayaPVP
{
    class Database
    {
        private string Data;
        public Database()
        {
            Data = "DataSource = UsersDatabase.db";
            if (File.Exists(@"UsersDatabase.db") == false)
            {
                InitializeDatabase();
            }
        }
        public bool InitializeDatabase()
        {
            SQLiteConnection connection = new SQLiteConnection(Data);
            try
            {
                connection.Open();
                SQLiteCommand cmd = connection.CreateCommand();
                string sql_command = "DROP TABLE IF EXISTS user;"
                + "CREATE TABLE user("
                + "ID INTEGER PRIMARY KEY AUTOINCREMENT, "
                + "login TEXT, "
                + "password TEXT)";

                cmd.CommandText = sql_command;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Dispose();
            }
            return true;
        }
        public bool CheckUser(string username, string password)
        {
            SQLiteConnection conn = new SQLiteConnection(Data);

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT COUNT(*) "
                + "FROM user "
                + "where login = '{0}' AND "
                + "password = '{1}'",
                username, password);
                var usersCount = Convert.ToInt32(cmd.ExecuteScalar());
                return usersCount > 0;
            }
            return false;
        }
        public bool CreateUser(string username, string password)
        {
            SQLiteConnection conn = new SQLiteConnection(Data);

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO user (login, password)"
                + "VALUES ('{0}', '{1}')",
                username, password);
                cmd.ExecuteNonQuery();
                return true;
            }
            return true;
        }
        public bool CheckCorrect(string username)
        {
            SQLiteConnection conn = new SQLiteConnection(Data);
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT COUNT(*) "
            + "FROM user "
            + "where login = '{0}'", username);
            int usersCount = Convert.ToInt32(cmd.ExecuteScalar());
            return usersCount > 0;
        }
    }
}
