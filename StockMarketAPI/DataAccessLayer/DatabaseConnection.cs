using MySql.Data.MySqlClient;

namespace StockMarketAPI.DataAccessLayer
{
    public class DatabaseConnection
    {
        private DatabaseConnection instance = null;
        private MySqlConnection connection = null;
        string connectionString = @"server=localhost; port=3306; user=root; password=1234567890; database=SolveTraining";

        private DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                return new DatabaseConnection();

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