using StockMarket.DataAccessLayer;
using StockMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StockMarket.Controllers
{
    public class StockController : ApiController
    {
        private readonly StockMarketContext db = new StockMarketContext();


        public IHttpActionResult Get()
        {
            List<Stock> allStocks = DbManager.GetAllStocks();
            Console.WriteLine("Get all stocks");
            allStocks.ForEach(stock =>
            {
                Console.WriteLine(stock);
            });
            return Json(allStocks);
        }

        public IHttpActionResult GetStockById(int id)
        {
            var stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return BadRequest($"Stock Doesn't exist of {id}");
            }
            return Json(stock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
