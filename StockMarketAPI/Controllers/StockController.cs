using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StockMarket.DataAccessLayer;
using StockMarket.DataTransferObject;
using StockMarket.Models;
using StockMarket.Utils;


namespace StockMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly StockMarketContext db = new StockMarketContext();

        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(DbManager.GetAllStocks());
        }

        [HttpPut]
        public IActionResult UpdateStockById(Stock stock1)
        {
            var stock = DbManager.UpdateStockById(stock1);
            if (stock == false)
            {
                return BadRequest($"Stock Doesn't exist of {stock1.StockId}");
            }
            return Ok(true);
        }

        [HttpPost]
        public IActionResult InsertOneStock(JObject stock)
        { 
            List<ErrorMessage> validationErrors = Validation.ValidateStock(stock);
            if (validationErrors.Any())
            {
                var response = new { success = false, errors = validationErrors };
                return BadRequest(response);
            }

            if (!DbManager.InsertOneStock(new Stock(new StockDTO().ConvertToStockDTO(stock))))
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Failed to insert stock into database." });

            return StatusCode(StatusCodes.Status201Created, new { success = true, message = "Inserted stock into database." });

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

        [HttpDelete]
        public IActionResult DeleteStockById(int id)
        {
            var stock = DbManager.DeleteStockById(id);
            if (stock == null)
            {
                return BadRequest($"Stock Doesn't exist of {id}");
            }

            return new JsonResult(stock);
        }

    }
}
