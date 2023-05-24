using Microsoft.AspNetCore.Mvc;
using StockMarketAPI.DataAccessLayer;
using StockMarketAPI.Models;
using StockMarketAPI.DataTransferObject;
using StockMarketAPI.Utils;
using log4net.Config;
using log4net.Core;
using log4net;
using System.Reflection;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using Microsoft.AspNetCore.Cors;
using StockMarketAPI.Scrapper;

namespace StockMarketAPI.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        #region Variables and Methods

        private readonly StockMarketContext db = new StockMarketContext();

        private void LogError(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
            _logger.Info(message);
        }

        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region GET

        [HttpGet]
        [Route("UpdatePricesOnline")]
        public IActionResult UpdatePricesOnline()
        {
            LogError("Updating Price in DB Online");
            if(StockPrice_Insertion.InsertPrice())
                return StatusCode(StatusCodes.Status200OK);
            return BadRequest(ErrorMessages.Errors[128]);

        }

        [HttpGet]
        [Route("GetAllStocks")]
        public IActionResult GetAllStocks()
        {
            LogError("Get All Stocks Called");
            return new JsonResult(DbManager.GetAllStocks());
            
        }
        [HttpGet]
        [Route("GetAllStocksWithPrice")]
        public IActionResult GetAllStocksWithPrice()
        {
            LogError("Get All Stocks Called");
            return new JsonResult(DbManager.GetAllStocksWithPrice());

        }

        [HttpGet]
        [Route("GetAllStocksWithoutPrice")]
        public IActionResult GetStocksWithoutPrice()
        {
            return new JsonResult(DbManager.StockWithoutPrice());
        }

        [HttpGet]
        [Route("StockbyId/{id}")]
        public IActionResult GetStockById(int id)
        {
            var stock = DbManager.StockById(id);
            if (stock == null)
            {
                return BadRequest($"Stock Doesn't exist of {id}");
            }
            return new JsonResult(stock);
        }

        [HttpGet]
        [Route("StockbySymbol/{symbol}")]
        public IActionResult GetStockBySymbol(string symbol)
        {
            var stock = DbManager.StockBySymbol(symbol);
            if (stock == null)
            {
                return BadRequest($"Stock Doesn't exist of this symbol");
            }
            return new JsonResult(stock);
        }

        [HttpGet]
        [Route("StockPriceOnline/{symbol}")]
        public IActionResult GetStockPriceOnline(string symbol)
        {
            var stockPrice = StockPrice_Scraper.GetOnlineStockPrice(symbol.ToUpper());
            if (stockPrice == null)
            {
                return BadRequest(ErrorMessages.Errors[129]);
            }
            return new JsonResult(new { StockSymbol = symbol.ToUpper(), StockPrice = stockPrice});
        }

        [HttpGet]
        [Route("StockByIdWithPrices/{id}")]
        public IActionResult StockByIdWithPrices(int id)    
        {
            var stock = DbManager.StockById(id);
            if (stock == null)
            {
                return BadRequest($"Stock Doesn't exist of {id}");
            }
            return StatusCode(StatusCodes.Status200OK, DbManager.StockByIdWithPrices(id));
        }

        [HttpGet]
        [Route("MathFunctions/{id}")]
        public IActionResult MathFunctions(int id, MathOperationDTO oprand)
        {
            var stock = DbManager.StockById(id);
            if (stock == null)
                return BadRequest(ErrorMessages.Errors[131] );

            var operation = StockService.MathFunctions(id, oprand);

            if(operation is ErrorMessage)
            {
                return StatusCode(StatusCodes.Status400BadRequest, operation);
            }

            return StatusCode(StatusCodes.Status200OK,
                operation == null ? ErrorMessages.Errors[127] : new
                {
                    stock.StockId,
                    stock.StockName,
                    stock.StockSymbol,
                    stock.CreationDate,
                    operation
                });
        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("UpdateStockById")]
        public HttpResponseMessage UpdateStockById(StockUpdateDTO stock1)
        {
            using (StreamWriter writer = new StreamWriter("D:\\apiUpdate.txt"))
            {
                writer.WriteLine("Reached to update stock");
            }
            var stock = DbManager.UpdateStockById(stock1);
            if (stock == false)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent($"Stock Doesn't exist of {stock1.StockId}")
                };
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        #endregion

        #region POST

        [HttpPost]
        [Route("InsertOneStock")]
        public IActionResult InsertOneStock(Stock stock)
        { /*
            List<ErrorMessage> validationErrors = Validation.ValidateStock(stock);
            if (validationErrors.Any())
            {
                var response = new { success = false, errors = validationErrors };
                return BadRequest(response);
            }
            */
            //if (!DbManager.InsertOneStock(new Stock(new StockDTO().ConvertToStockDTO(stock))))
            if (!DbManager.InsertOneStock(stock))
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Failed to insert stock into database." });

            return StatusCode(StatusCodes.Status201Created, new { success = true, message = "Inserted stock into database." });

        }

        [HttpPost]
        [Route("InsertStockPriceById")]
        public IActionResult InsertStockPriceById(StockPrice stock)
        { /*
            List<ErrorMessage> validationErrors = Validation.ValidateStock(stock);
            if (validationErrors.Any())
            {
                var response = new { success = false, errors = validationErrors };
                return BadRequest(response);
            }*/

            //if (!DbManager.InsertOneStock(new Stock(new StockDTO().ConvertToStockDTO(stock))))
            if (!DbManager.InsertStockPriceById(stock))
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Failed to insert Stock Price into database." });

            return StatusCode(StatusCodes.Status201Created, new { success = true, message = "Inserted stock into database." });

        }
        #endregion

        #region DELETE

        [HttpDelete]
        [Route("DeleteStock/{id}")]
        public IActionResult DeleteStockById(int id)
        {
            var stock = DbManager.DeleteStockById(id);
            if (stock == null)
            {
                return BadRequest($"Stock Doesn't exist of id {id}");
            }

            return StatusCode(StatusCodes.Status202Accepted, new { Sucess = true, message = "Sucessfully Deleted." });
        }
        #endregion

    }
}
