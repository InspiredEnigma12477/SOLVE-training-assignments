using StockMarketAPI.DataAccessLayer;
using StockMarketAPI.Models;

namespace StockMarketAPI.Scrapper
{
    public class StockPrice_Insertion
    {

        public static bool InsertPrice()
        { 
            List<Thread> threads = new List<Thread>();
            List<Stock> stocks = DbManager.GetAllStocks();

            int numThreads = 20;
            int stocksPerThread = stocks.Count / numThreads;

            // Create and start threads
            for (int i = 0; i < numThreads; i++)
            {
                int startIndex = i * stocksPerThread;
                int endIndex = (i == numThreads - 1) ? stocks.Count : startIndex + stocksPerThread;

                List<Stock> threadStocks = stocks.GetRange(startIndex, endIndex - startIndex);

                Thread thread = new Thread(() => ProcessStocks(threadStocks));
                thread.Start();
                threads.Add(thread);
            }

            // Wait for all threads to complete
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All threads completed. Press any key to exit.");

            return true;

        }
        static void ProcessStocks(List<Stock> stocks)
        {
            foreach (Stock stock in stocks)
            {
                double? price = StockPrice_Scraper.GetOnlineStockPrice(stock.StockSymbol);

                try
                {
                    DbManager.InsertStockPriceById(new StockPrice
                    {
                        StockId = stock.StockId,
                        Price = (double)price,
                        AtTime = DateTime.Now
                    });
                }
                catch
                {
                    Console.WriteLine("Got an error");
                    continue;
                }
            }
        }
        public static bool InsertPriceT()
        {
            List<Stock> stocks = DbManager.GetAllStocks();
            ProcessStocks(stocks);
            return true;
        }

    }
}
