﻿using MySql.Data.MySqlClient;
using StockMarketAPI.DataTransferObject;
using StockMarketAPI.Models;


namespace StockMarketAPI.DataAccessLayer
{
    public class DbManager
    {
        public DbManager() { }

        #region GET Methods
        public static int? GetStocksCount()
        {
            int? result = null;

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                string query = "SELECT Count(*) \"Count\" FROM stocks ";
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                result = int.Parse(reader["Count"].ToString());

                using (StreamWriter writer = new StreamWriter("D:\\Coumt.txt"))
                {
                    writer.Write(result);
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

            return result;
        }
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
                    var id = int.Parse(reader["StockId"].ToString());
                    var stockName = reader["StockName"].ToString();
                    var stockSymbol = reader["StockSymbol"].ToString();
                    var creationDate = reader["CreationDate"].ToString();

                    Stock stock = new Stock
                    {
                        StockId = id,
                        StockName = stockName,
                        StockSymbol = stockSymbol,
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
        public static List<Stock> GetAllStocksPagination(int Pageid)
        {
            List<Stock> allStocks = new List<Stock>();

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                string query = $"SELECT * FROM stocks LIMIT {Pageid * 100},100 ";
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["StockId"].ToString());
                    var stockName = reader["StockName"].ToString();
                    var stockSymbol = reader["StockSymbol"].ToString();
                    var creationDate = reader["CreationDate"].ToString();

                    Stock stock = new Stock
                    {
                        StockId = id,
                        StockName = stockName,
                        StockSymbol = stockSymbol,
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
        public static List<StockWithPrice> GetAllStocksWithPrice()
        {

            List<StockWithPrice> allStocks = new List<StockWithPrice>();
            using (StreamWriter writer = new StreamWriter("D:\\SQLStockWithprices.txt"))
            {
                writer.WriteLine("Inside");


                MySqlConnection con = DatabaseConnection.Instance.GetConnection();
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    string query = "SELECT s.*, price FROM stocks AS s JOIN Stock_Price AS sp ON s.stockId = sp.stockId WHERE sp.priceAtTime = ( Select Max(PriceAtTime) FROM Stock_Price WHERE stockId = s.stockId)";
                    cmd.CommandText = query;

                    writer.WriteLine(query);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var id = int.Parse(reader["StockId"].ToString());
                        var stockName = reader["StockName"].ToString();
                        var stockSymbol = reader["StockSymbol"].ToString();
                        var stockPrice = double.Parse(reader["Price"].ToString());
                        var creationDate = reader["CreationDate"].ToString();

                        writer.WriteLine(id + " " + stockName + " " + stockSymbol + " " + stockPrice + " " + creationDate);
                        StockWithPrice stock = new StockWithPrice
                        {
                            StockId = id,
                            StockName = stockName,
                            StockSymbol = stockSymbol,
                            StockPrice = stockPrice,
                            CreationDate = DateTime.Parse(creationDate)
                        };
                        allStocks.Add(stock);
                    }
                }

                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                    writer.Write(ee.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return allStocks;
        }
        public static List<Stock> StockWithoutPrice()
        {
            List<Stock> allStocks = new List<Stock>();

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                string query = "SELECT * FROM stocks WHERE NOT EXISTS (SELECT 1 FROM stock_price WHERE stock_price.stockId = stocks.StockId)";

                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["StockId"].ToString());
                    var stockName = reader["StockName"].ToString();
                    var stockSymbol = reader["StockSymbol"].ToString();
                    var creationDate = reader["CreationDate"].ToString();

                    Stock stock = new Stock
                    {
                        StockId = id,
                        StockName = stockName,
                        StockSymbol = stockSymbol,
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
        public static List<Stock> StockWithoutPrice2()
        {
            List<Stock> allStocks = new List<Stock>();

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                string query = "SELECT s.* FROM stocks s LEFT JOIN stock_price sp on s.StockId = sp.StockId WHERE sp.StockId IS NULL";

                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = int.Parse(reader["StockId"].ToString());
                    var stockName = reader["StockName"].ToString();
                    var stockSymbol = reader["StockSymbol"].ToString();
                    var creationDate = reader["CreationDate"].ToString();

                    Stock stock = new Stock
                    {
                        StockId = id,
                        StockName = stockName,
                        StockSymbol = stockSymbol,
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
        public static object StockByIdWithPrices(int id)
        {
            var prices = DbManager.StockPrices(id).Select(s => new { s.Price, s.AtTime }).OrderByDescending(s => s.AtTime).ToList();
            Stock stock = DbManager.StockById(id);

            return new
            {
                stock.StockId,
                stock.StockName,
                stock.StockSymbol,
                prices
            };
        }
        public static List<StockPrice> StockPrices(int id)
        {
            List<StockPrice> allStocks = new List<StockPrice>();

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                string query = $"SELECT * FROM stock_price sp WHERE StockId = {id}";

                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id1 = int.Parse(reader["StockId"].ToString());
                    var price = double.Parse(reader["Price"].ToString());
                    var atTime = reader["PriceAtTime"].ToString();

                    StockPrice stock = new StockPrice
                    {
                        StockId = id,
                        Price = price,
                        AtTime = DateTime.Parse(atTime)
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
        public static double? StockByIdAvg(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT AVG(price) \"AVG_Price\" FROM stock_Price Where StockId ={id}";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return double.Parse(reader["AVG_Price"].ToString());
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
        public static double? StockByIdMin(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT MIN(price) \"MIN_Price\" FROM stock_Price Where StockId ={id}";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return double.Parse(reader["MIN_Price"].ToString());
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
        public static double? StockByIdMax(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT MAX(price) \"MAX_Price\" FROM stock_Price Where StockId ={id}";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return double.Parse(reader["MAX_Price"].ToString());
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
        public static double? StockByIdAvg(int id, string date)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT AVG(price) \"AVG_Price\" FROM stock_Price Where StockId ={id} AND PriceAtTime BETWEEN '{date} 00:00:00' AND '{date} 23:59:59'";
            try
            {
                using (StreamWriter writer = new StreamWriter("D:\\error.txt"))
                {
                    writer.Write(query);
                }
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return double.Parse(reader["AVG_Price"].ToString());
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        public static double? StockByIdMin(int id, string date)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            //cast priceattime in date then compare
            string query = $"SELECT MIN(price) \"MIN_Price\" FROM stock_Price Where StockId ={id} AND PriceAtTime BETWEEN '{date} 00:00:00' AND '{date} 23:59:59'";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return double.Parse(reader["MIN_Price"].ToString());
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        public static double? StockByIdMax(int id, string date)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT MAX(price) \"MAX_Price\" FROM stock_Price Where StockId ={id} AND PriceAtTime BETWEEN '{date} 00:00:00' AND '{date} 23:59:59'";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                    return double.Parse(reader["MAX_Price"].ToString());
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            finally
            {
                con.Close();
            }
            return null;
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
                        /*Price = double.Parse(reader["Price"].ToString()),*/
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
        public static Stock StockBySymbol(string symbol)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            string query = $"SELECT * FROM stocks Where StockSymbol =\"{symbol}\"";
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
        #endregion

        #region DELETE Methods
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
                    DeleteStockPricesById(id);
                    string query = "DELETE FROM stocks WHERE StockId =" + id;
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
        public static bool DeleteStockPricesById(int id)
        {
            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                string query = "DELETE FROM stock_price WHERE StockId =" + id;
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        #endregion

        #region POST Methods
        public static bool InsertOneStock(StockInsertDTO stock)
        {
            bool status = false;

            string query = $"INSERT INTO stocks (StockName, StockSymbol, CreationDate) VALUES('{stock.StockName}', '{stock.StockSymbol}', NOW())";

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
        public static bool InsertMultipleStock(List<StockInsertDTO> stocks)
        {
            bool status = false;


            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();
                foreach (StockInsertDTO stock in stocks)
                {
                    string query = $"INSERT INTO stocks (StockName, StockSymbol, CreationDate) VALUES('{stock.StockName}', '{stock.StockSymbol}', NOW())";

                    MySqlCommand command = new MySqlCommand(query, con);
                    command.ExecuteNonQuery();
                    status = true;
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

            return status;

        }
        public static bool InsertStockPriceById(StockPrice stock)
        {
            bool status = false;
            stock.AtTime = DateTime.Now;

            string query = $"INSERT INTO stock_Price (StockId, Price, PriceAtTime) VALUES('{stock.StockId}', '{stock.Price}', NOW())";

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

        public static bool InsertMultipleStockPriceById(List<StockPrice> stocks)
        {
            bool status = false;

            MySqlConnection con = DatabaseConnection.Instance.GetConnection();
            try
            {
                con.Open();
                foreach (StockPrice stock in stocks)
                {
                    stock.AtTime = DateTime.Now;
                    string query = $"INSERT INTO stock_Price (StockId, Price, PriceAtTime) VALUES('{stock.StockId}', '{stock.Price}', NOW())";

                    MySqlCommand command = new MySqlCommand(query, con);
                    command.ExecuteNonQuery();
                }
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
        public static bool UpdateStockById(StockUpdateDTO stock)
        {
            bool status = false;
            string query = $"UPDATE stocks SET StockName = '{stock.StockName}',StockSymbol = '{stock.StockSymbol}' WHERE StockId = {stock.StockId}";
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

        #region Boolean Methods
        public static bool IsStockSymbolExist(string StockSymbol)
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
        public static bool IsStockNameExist(string StockName)
        {
            bool status = false;
            string query = $"Select COUNT(*) FROM stocks WHERE StockName = '{StockName}'";
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

        internal static void InsertStockPriceById(object value)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}