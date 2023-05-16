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
		public IActionResult AddStock()
		{
			return View();
		}

		[HttpGet]
		[Route("DisplayAllStocks")]
		public async Task<IActionResult> DisplayAllStocks()
		{
			ViewBag.stocks = await _stockService.GetAllStock();
			return View();
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
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}