using Microsoft.AspNetCore.Mvc;
using StockMarket.DataAccessLayer;
using StockMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IHttpActionResult UpdateStockById(Stock stock1)
        {
            var stock = DbManager.UpdateStockById(stock1);
            if (stock == false)
            {
                return BadRequest($"Stock Doesn't exist of {stock1.StockId}");
            }
            return Ok(true);
        }

        public IHttpActionResult InsertOneStock(Stock stock1)
        {
            var status = DbManager.InsertOneStock(stock1);
            if (status == false)
            {
                return BadRequest($"Insertion was unsuccessful");
            }
            else
                return Ok(true);
        }

        public IHttpActionResult GetStockById(int id)
        {
            var stock = DbManager.StockById(id);
            if (stock == null)
            {
                return BadRequest($"Stock Doesn't exist of {id}");
            }
            return Json(stock);
        }

        public IHttpActionResult DeleteStockById(int id)
        {
            var stock = DbManager.DeleteStockById(id);
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
