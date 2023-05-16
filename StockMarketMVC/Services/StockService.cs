using Newtonsoft.Json;
using StockMarketMVC.Controllers;
using StockMarketMVC.Models;
using System.Net.Http.Headers;
using System.Text;

namespace StockMarketMVC.Services
{
    public class StockService
    {
        private readonly HttpClient _httpClient;
        public StockService() {
            
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri("http://localhost:5232/Stock/");
            
        }


        public async void AddStock(StockDto stock)
        {
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

    }
}
