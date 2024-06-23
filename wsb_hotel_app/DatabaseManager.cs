using System;
using System.Data.SQLite;
using System.IO;

namespace wsb_hotel_app
{
   
    public class DatabaseManager
    {     
        private string databasePath;
        private const string fileName = "users.db";
   
        public DatabaseManager()
        {

            databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }
        public string GetDatabasePath()
        {
            return databasePath;
        }

        public void InitializeDatabase()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory);


            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);

                using (var connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
                {
                    connection.Open();


                    string createUserTableQuery = @"CREATE TABLE IF NOT EXISTS users (
                                                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        firstName TEXT NOT NULL,
                                                        lastName TEXT NOT NULL,
                                                        email TEXT UNIQUE NOT NULL,
                                                        password TEXT NOT NULL
                                                    );";

                    using (var command = new SQLiteCommand(createUserTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

      
        public void AddUser(string firstName, string lastName, string email, string password)
        {

            if (!File.Exists(databasePath))
            {
                InitializeDatabase();
            }

            using (var connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();


                string insertUserQuery = @"INSERT INTO users (firstName, lastName, email, password)
                                           VALUES (@firstName, @lastName, @email, @password);";

                using (var command = new SQLiteCommand(insertUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckUserExists(string email)
        {

            if (!File.Exists(databasePath))
            {
                InitializeDatabase();
            }

            using (var connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                string checkUserQuery = "SELECT COUNT(*) FROM users WHERE email = @email;";

                using (var command = new SQLiteCommand(checkUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }


        public bool AuthenticateUser(string email, string password)
        {

            if (!File.Exists(databasePath))
            {
                InitializeDatabase();
            }

            using (var connection = new SQLiteConnection($"Data Source={databasePath};Version=3;"))
            {
                connection.Open();

                string authenticateUserQuery = "SELECT COUNT(*) FROM users WHERE email = @email AND password = @password;";

                using (var command = new SQLiteCommand(authenticateUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }
    }
}