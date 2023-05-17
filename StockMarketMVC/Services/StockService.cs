using Newtonsoft.Json;
using StockMarketMVC.Controllers;
using StockMarketMVC.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StockMarketMVC.Services
{
	public class StockService
	{
		private readonly HttpClient _httpClient;

		public StockService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://localhost:7140/Stock/");
		}

		public async void AddStock(string stockName, string stockSymbol)
		{
			var stock = new StockInsertDto { StockName = stockName, StockSymbol = stockSymbol };
			string jsonStock = JsonConvert.SerializeObject(stock);
			StringContent content = new StringContent(jsonStock, Encoding.UTF8, "application/json");
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			HttpResponseMessage response = await _httpClient.PostAsync(@"InsertOneStock", content);
		}

		public async Task<List<Stock>> GetAllStock()
		{
			HttpResponseMessage response = await _httpClient.GetAsync(@"GetAllStocks");
			string responseBody = await response.Content.ReadAsStringAsync();
			List<Stock> stocks = JsonConvert.DeserializeObject<List<Stock>>(responseBody);
			return stocks;
		}

		public async Task<bool> DeleteStock(int stockId)
		{
			string url = $"DeleteStock/{stockId}";
			HttpResponseMessage response = await _httpClient.DeleteAsync(url);

			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> UpdateStock(string stockId, string stockName, string stockSymbol)
		{
			var stock = new StockUpdateDto
			{
				StockId = int.Parse(stockId),
				StockName = stockName,
				StockSymbol = stockSymbol
			};
			string jsonStock = JsonConvert.SerializeObject(stock);
			StringContent content = new StringContent(jsonStock, Encoding.UTF8, "application/json");
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			string url = $"UpdateStockById";
			HttpResponseMessage response = await _httpClient.PutAsync(@"UpdateStockById", content);
           
            if (response.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
