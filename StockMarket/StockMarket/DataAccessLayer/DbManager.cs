using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using MySql.Data.MySqlClient;
using StockMarket.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                    string price = reader["Price"].ToString();
                    string creationDate = reader["CreationDate"].ToString();

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

        #endregion

        #region Put Methods
        public static bool InsertOneStock(Stock stock)
        {
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
            Stock stock;
            try{
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                string query = $"SELECT * FROM stocks Where StockId ={id}";
                cmd.CommandText = query;
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id1 = int.Parse(reader["StockId"].ToString());
                    string stockName = reader["StockName"].ToString();
                    string stockSymbol = reader["StockSymbol"].ToString();
                    string price = reader["Price"].ToString();
                    string creationDate = reader["CreationDate"].ToString();

                    if (id1 == id)
                    {
                        stock = new Stock
                        {
                            StockId = id,
                            StockName = stockName,
                            StockSymbol = stockSymbol,
                            Price = price,
                            CreationDate = creationDate
                        };
                        return stock;
                    }
                    else
                    {
                        return null;
                    }
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
                if(stock == null)
                {
                    return null;
                }
                if (stock.StockId == id)
                {
                    string query = " DELETE FROM stocks WHERE StockId =" + id;
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return stock ;
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
    }
}