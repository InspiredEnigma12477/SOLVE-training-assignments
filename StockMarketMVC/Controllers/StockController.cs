using Microsoft.AspNetCore.Mvc;
using StockMarketMVC.Models;
using StockMarketMVC.Services;
using System.Diagnostics;
using System.Net.Http;

namespace StockMarketMVC.Controllers
{
    [Route("[controller]")]
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private readonly StockService _stockService;

        public StockController()
        {
            _stockService = new StockService();
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("AddStock")]
        public async Task<IActionResult> AddStockPage()
        {
            var stocks = await _stockService.GetAllStock();
            var viewModel = new StockViewModel
            {
                Stocks = stocks
            };
            return View(viewModel);
            /*ViewBag.stocks = await _stockService.GetAllStock();
            return View();*/
        }

        [HttpPost]
        [Route("AddStock")]
        public IActionResult AddStock(string stockName, string stockSymbol)
        {
            _stockService.AddStock(stockName, stockSymbol);
            return RedirectToAction("AddStockPage", "Stock");
        }

        [HttpGet]
        [Route("UpdateStock/{id}")]
        public IActionResult UpdateStockPage()
        {
            return View();
        }

        [HttpPost]
        [Route("UpdateStock")]
        public async Task<IActionResult> UpdateStock(string stockId, string stockName, string stockSymbol)
        {
            bool result = await _stockService.UpdateStock(stockId, stockName, stockSymbol);
            if (!result)
            {
                return RedirectToAction($"Index", "Home");
            }
            else
            {
                return RedirectToAction("DisplayAllStocks", "Stock");
            }
        }

        [HttpGet]
        [Route("DisplayAllStocks")]
        public async Task<IActionResult> DisplayAllStocks()
        {
            var stocks = await _stockService.GetAllStock();
            var viewModel = new StockViewModel
            {
                Stocks = stocks
            };
            return View(viewModel);
            /*ViewBag.stocks = await _stockService.GetAllStock();
            return View();*/
        }

        [HttpGet]
        [Route("DeleteStock/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await _stockService.DeleteStock(id);
            return RedirectToAction("DisplayAllStocks", "Stock");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
