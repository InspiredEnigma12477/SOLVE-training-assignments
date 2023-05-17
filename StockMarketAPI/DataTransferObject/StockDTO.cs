using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace StockMarketAPI.DataTransferObject
{
    public class StockDTO
    {
        [JsonProperty("StockId")]
        public int StockId { get; set; }

        [JsonProperty("StockName")]
        [Required(ErrorMessage = "Stock name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Stock name must be between 3 and 50 characters")]
        public string StockName { get; set; }


        [JsonProperty("StockSymbol")]
        [Required(ErrorMessage = "Stock symbol is required")]
        [RegularExpression("^[A-Za-z]{3,10}$", ErrorMessage = "Invalid stock symbol format")]
        public string StockSymbol { get; set; }


        /*[JsonProperty("Price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1000000")]
        public double Price { get; set; }*/


        [JsonProperty("CreationDate")]
        public DateTime CreationDate { get; set; }

        public StockDTO ConvertToStockDTO(JObject stock) {
            return stock.ToObject<StockDTO>();
        }

    }
    public class StockUpdateDTO
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
    }
}