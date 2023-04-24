using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using MySql.Data.MySqlClient;
using StockMarket.Models;

namespace StockMarket.DataAccessLayer
{
    public class DbManager
    {
        public static Guid StockId { get; private set; }

        public DbManager() { }

        public static List<Stock> GetAllStocks()
        {
            List<Stock> allStocks = new List<Stock>();

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                string query = "SELECT * FROM stocks";
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["StockId"].ToString());
                    string stockName = reader["StockName"].ToString();
                    string stockSymbol = reader["StockSymbol"].ToString();
                    double price = double.Parse(reader["Price"].ToString());
                    DateTime creationDate = DateTime.Parse(reader["CreationDate"].ToString());

                    Stock stock = new Stock
                    {
                        StockId = id,
                        StockName = stockName,
                        StockSymbol = stockSymbol,
                        Price = price,
                        CreationDate = creationDate
                    };
                    allStocks.Add(stock);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return allStocks;
        }
    }
}