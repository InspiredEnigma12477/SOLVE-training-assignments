using Microsoft.AspNetCore.Mvc;
using StockMarketMVC.Models;
using StockMarketMVC.Services;
using System.Diagnostics;
using System.Net.Http;

namespace StockMarketMVC.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private readonly StockService _stockService;
        public StockController()
        {
            _stockService = new StockService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStock()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DisplayAllStocks()
        {
            ViewBag.stocks = await _stockService.GetAllStock();
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}