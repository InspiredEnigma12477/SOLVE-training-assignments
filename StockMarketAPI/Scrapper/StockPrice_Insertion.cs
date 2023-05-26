using StockMarketAPI.DataAccessLayer;
using StockMarketAPI.Models;

namespace StockMarketAPI.Scrapper
{
    public class StockPrice_Insertion
    {

        private static List<StockPrice> staticlist = new List<StockPrice>();

        public static bool InsertPrice()
        {
            staticlist.Clear();

            List<Thread> threads = new List<Thread>();
            List<Stock> stocks = DbManager.GetAllStocks();

            int numThreads = 10;
            int stocksPerThread = stocks.Count / numThreads;

            // Create and start threads
            for (int i = 0; i < numThreads; i++)
            {
                int startIndex = i * stocksPerThread;
                int endIndex = (i == numThreads - 1) ? stocks.Count : startIndex + stocksPerThread;

                List<Stock> threadStocks = stocks.GetRange(startIndex, endIndex - startIndex);

                //Thread thread = new Thread(() => ProcessStocks(threadStocks));
                //thread.Start();
                //threads.Add(thread);
            }

            // Wait for all threads to complete
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All threads completed. Press any key to exit.");
            InsertInDB();
            Console.WriteLine("Inserted the data");

            return true;

        }
        static void ProcessStocks(List<Stock> stocks)
        {
            foreach (Stock stock in stocks)
            {
                try
                {
                    double? price = StockPrice_Scraper.GetOnlineStockPrice(stock.StockSymbol);
                    if (price != null)
                    {
                        staticlist.Add(new StockPrice
                        {
                            StockId = stock.StockId,
                            Price = (double)price,
                            AtTime = DateTime.Now
                        });
                    }
                }
                catch
                {
                    Console.WriteLine("Got an error while Scrapping");
                    continue;
                }
            }
        }

        public static bool InsertInDB()
        {
            foreach (StockPrice stock in staticlist)
            {
                try
                {
                    DbManager.InsertStockPriceById(stock);
                }
                catch
                {
                    Console.WriteLine("Got an error while inserting");
                    continue;
                }
            }
            return true;
        }
        public static bool InsertPriceT()
        {
            List<Stock> stocks = DbManager.GetAllStocks();
            ProcessStocks(stocks);
            return true;
        }

    }
}
