using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using MySql.Data.MySqlClient;
using StockMarket.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StockMarket.DataAccessLayer
{
    public class DbManager
    {
        public static Guid StockId { get; private set; }

        public DbManager() { }


        #region Get Methods
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
                    int id = int.Parse(reader["StockId"].ToString());
                    string stockName = reader["StockName"].ToString();
                    string stockSymbol = reader["StockSymbol"].ToString();
                    double price = double.Parse(reader["Price"].ToString());
                    string creationDate = reader["CreationDate"].ToString();

                    Stock stock = new Stock
                    {
                        StockId = id,
                        StockName = stockName,
                        StockSymbol = stockSymbol,
                        Price = price,
                        CreationDate = DateTime.Parse(creationDate)
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

        #endregion

        #region Put Methods
        public static bool InsertOneStock(Stock stock)
        {
            new StreamWriter("D:\\trail_stocks.txt").WriteLine(stock.ToString());
            bool status = false;
            string query = $"INSERT INTO stocks (StockId, StockName, StockSymbol, Price, CreationDate) VALUES( {stock.StockId}, '{stock.StockName}', '{stock.StockSymbol}', {stock.Price}, '{stock.CreationDate}')";
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                status = true;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return status;

        }

        #endregion
        public static bool UpdateStockById(Stock stock)
        {
            bool status = false;
            string query = $"UPDATE stocks SET StockName = '{stock.StockName}',StockSymbol = '{stock.StockSymbol}', Price ={stock.Price},CreationDate = '{stock.CreationDate}' WHERE StockId = {stock.StockId}";
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                status = true;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return status;

        }

        public static Stock StockById(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT * FROM stocks Where StockId ={id}";
            try
            {
                MySqlCommand command = new MySqlCommand(query, con);
                con.Open();

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Stock
                    {
                        StockId = int.Parse(reader["StockId"].ToString()),
                        StockName = reader["StockName"].ToString(),
                        StockSymbol = reader["StockSymbol"].ToString(),
                        Price = double.Parse(reader["Price"].ToString()),
                        CreationDate = DateTime.Parse(reader["CreationDate"].ToString())
                    };
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public static Stock DeleteStockById(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                Stock stock = StockById(id);
                if (stock == null)
                {
                    return null;
                }
                if (stock.StockId == id)
                {
                    string query = " DELETE FROM stocks WHERE StockId =" + id;
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return stock;
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

            return null;
        }


        public static bool IsStockExist(string StockSymbol)
        {
            bool status = false;
            string query = $"Select COUNT(*) FROM stocks WHERE StockSymbol = '{StockSymbol}'";
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                int count = Convert.ToInt32(command.ExecuteScalar());
                status = count > 0;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

            return status;

        }
    }
}