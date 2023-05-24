using Microsoft.AspNetCore.Mvc;
using StockMarketEFAPI.DataAccessLayer;
using StockMarketEFAPI.Models;
using StockMarketEFAPI.DataTransferObject;
using StockMarketEFAPI.Utils;
using log4net.Config;
using log4net.Core;
using log4net;
using System.Reflection;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using Microsoft.AspNetCore.Cors;

namespace StockMarketEFAPI.Controllers
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
        [Route("GetAllStocks")]
        public IActionResult GetAllStocks()
        {
            LogError("Get All Stocks Called");
            return new JsonResult(DbManager.GetAllStocks());
        }

        [HttpGet]
        [Route("StocksWithoutPrice")]
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
                return BadRequest($"Stock Doesn't exist of {id}");

            var operation = StockService.MathFunctions(id, oprand);
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
