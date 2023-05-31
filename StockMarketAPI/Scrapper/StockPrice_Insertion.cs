using StockMarketAPI.DataAccessLayer;
using StockMarketAPI.Models;
using System.Diagnostics;
using System.Threading;

namespace StockMarketAPI.Scrapper
{
    public class StockPrice_Insertion
    {
        private List<StockPrice> staticlist;
        private List<Thread> threads;
        private Semaphore dbSemaphore;
        
        public StockPrice_Insertion()
        {
            staticlist = new List<StockPrice>();
            threads = new List<Thread>();
            dbSemaphore = new Semaphore(initialCount: 0, maximumCount: 3);
            
        }
        public bool InsertPrice()
        {
            List<Stock> stocks = DbManager.GetAllStocks();   

            int numThreads = 320;
            int stocksPerThread = 5;

            // Create and start threads
            for (int i = 0; i < numThreads; i++)
            {
                int startIndex = i * stocksPerThread;
                int endIndex = (i == numThreads - 1) ? stocks.Count : startIndex + stocksPerThread;

                List<Stock> threadStocks = stocks.GetRange(startIndex, endIndex - startIndex);

                Thread thread = new Thread(() => ProcessStocks(threadStocks)) { Name = "thread" + i };
                thread.Start();
                threads.Add(thread);
                Console.ForegroundColor = ConsoleColor.White;
            }

            dbSemaphore.Release(releaseCount: 3);

            // Wait for all threads to complete
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All threads completed. Press any key to exit.");
            //InsertInDB();
            //Console.WriteLine("Inserted the data");

            return true;
        }
        void ProcessStocks(List<Stock> stocks)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();
            List<StockPrice> list = new List<StockPrice>();

            Console.WriteLine(Thread.CurrentThread.Name + "Stocks Count " + stocks.Count);
            foreach (Stock stock in stocks)
            {
                try
                {
                    double? price = StockPrice_Scraper.GetOnlineStockPrice(stock.StockSymbol);
                    if (price != null)
                    {
                        list.Add(new StockPrice
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
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Scraping completed in " + sw.Elapsed +  " for " + Thread.CurrentThread.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Insertion  Stopped for " + Thread.CurrentThread.Name);
            Console.ForegroundColor = ConsoleColor.White;

            dbSemaphore.WaitOne();// Wait until a DB connection is available
            InsertInDB(list);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insertion  Started for " + Thread.CurrentThread.Name);
            Console.ForegroundColor = ConsoleColor.White;

            dbSemaphore.Release(); // Release the DB connection

            
            Console.WriteLine("\nInserted     in DB for "  + Thread.CurrentThread.Name + " *****************");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

        }

        //public bool InsertInDB()
        public bool InsertInDB(List<StockPrice> list)
        {
            foreach (StockPrice stock in list)
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
        public bool InsertPriceT()
        {
            List<Stock> stocks = DbManager.GetAllStocks();
            ProcessStocks(stocks);
            return true;
        }

    }
}
