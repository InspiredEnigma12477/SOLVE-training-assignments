﻿using MySql.Data.MySqlClient;

namespace StockMarketEFAPI.DataAccessLayer
{
    public class DatabaseConnection
    {
        private static DatabaseConnection instance = null;
        private static MySqlConnection connection = null;
        string connectionString = @"server=localhost; port=3306; user=root; password=1234567890; database=SolveTraining";

        private DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }

        public MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
            }
            return connection;
        }
    }
}