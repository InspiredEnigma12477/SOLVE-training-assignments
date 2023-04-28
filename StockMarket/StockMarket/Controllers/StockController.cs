using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockMarket.DataAccessLayer;
using StockMarket.DataTransferObject;
using StockMarket.Models;
using StockMarket.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace StockMarket.Controllers
{
    [ApiController]
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

        public IHttpActionResult InsertOneStock(JObject stock)
        { 
            List<ErrorMessage> validationErrors = Validation.ValidateStock(stock);
            if (validationErrors.Any())
            {
                var response = new { success = false, errors = validationErrors };
                return Content(HttpStatusCode.BadRequest, response);
            }

            if (!DbManager.InsertOneStock(new Stock(new StockDTO().ConvertToStockDTO(stock))))
                return Content(HttpStatusCode.InternalServerError, new { success = false, message = "Failed to insert stock into database." });

            return Content(HttpStatusCode.OK, new { success = true, message = "Inserted stock into database." });

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
