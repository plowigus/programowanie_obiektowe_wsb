using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace wsb_hotel_app
{
    public class HotelDatabaseManager
    {
       
        private string databasePath;       
        private const string fileName = "reservation.db";       
        public HotelDatabaseManager()
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

            string connectionString = $"Data Source={databasePath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createRoomsTableQuery = @"CREATE TABLE IF NOT EXISTS rooms (
                                            roomId INTEGER PRIMARY KEY AUTOINCREMENT,
                                            roomNumber INTEGER NOT NULL,
                                            roomType TEXT NOT NULL,
                                            pricePerNight REAL NOT NULL,
                                            isAvailable INTEGER NOT NULL
                                        );";

                using (var command = new SQLiteCommand(createRoomsTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }


                string createReservationsTableQuery = @"CREATE TABLE IF NOT EXISTS reservations (
                                            reservationId INTEGER PRIMARY KEY AUTOINCREMENT,
                                            roomId INTEGER NOT NULL,
                                            clientId INTEGER NOT NULL,
                                            firstName TEXT NOT NULL,
                                            lastName TEXT NOT NULL,
                                            startDate TEXT NOT NULL,
                                            endDate TEXT NOT NULL,
                                            FOREIGN KEY (roomId) REFERENCES rooms (roomId)
                                        );";

                using (var command = new SQLiteCommand(createReservationsTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

       
        public void AddReservation(int roomId, string firstName, string lastName, DateTime startDate, DateTime endDate)
        {
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

              
                int clientId;
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                {
                    Random random = new Random();
                    clientId = random.Next(1000, 9999); 
                }
                else
                {                  
                    string fullName = firstName + lastName;
                    clientId = fullName.GetHashCode();
                }

               
                string insertReservationQuery = @"INSERT INTO reservations (roomId, clientId, firstName, lastName, startDate, endDate)
                                  VALUES (@roomId, @clientId, @firstName, @lastName, @startDate, @endDate);";

                using (var command = new SQLiteCommand(insertReservationQuery, connection))
                {
                    command.Parameters.AddWithValue("@roomId", roomId);
                    command.Parameters.AddWithValue("@clientId", clientId);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        private bool RoomExists(int roomNumber)
        {
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                string query = "SELECT COUNT(*) FROM rooms WHERE roomNumber = @roomNumber;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomNumber", roomNumber);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

 
        public void AddRoom(int roomNumber, string roomType, double pricePerNight, bool isAvailable)
        {
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertRoomQuery = @"INSERT INTO rooms (roomNumber, roomType, pricePerNight, isAvailable)
                                           VALUES (@roomNumber, @roomType, @pricePerNight, @isAvailable);";

                using (var command = new SQLiteCommand(insertRoomQuery, connection))
                {
                    command.Parameters.AddWithValue("@roomNumber", roomNumber);
                    command.Parameters.AddWithValue("@roomType", roomType);
                    command.Parameters.AddWithValue("@pricePerNight", pricePerNight);
                    command.Parameters.AddWithValue("@isAvailable", isAvailable ? 1 : 0);

                    command.ExecuteNonQuery();
                }
            }
        }

 
        public int GetRoomIdByNumber(int roomNumber)
        {
            string connectionString = $"Data Source={databasePath};Version=3;";
            int roomId = -1;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT roomId FROM rooms WHERE roomNumber = @roomNumber;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomNumber", roomNumber);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            roomId = reader.GetInt32(0);
                        }
                    }
                }
            }

            return roomId;
        }

 
        public List<int> GetAllRoomNumbers()
        {
            List<int> roomNumbers = new List<int>();

            string connectionString = $"Data Source={databasePath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT roomNumber FROM rooms;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomNumbers.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            return roomNumbers;
        }

  
        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            string connectionString = $"Data Source={databasePath};Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM reservations;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reservation reservation = new Reservation(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                DateTime.Parse(reader.GetString(5)),
                                DateTime.Parse(reader.GetString(6))
                            );
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            Console.WriteLine($"Found {reservations.Count} reservations in the database.");
            return reservations;
        }


    }

}