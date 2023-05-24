using System.ComponentModel.DataAnnotations;
using StockMarketEFAPI.DataTransferObject;

namespace StockMarketEFAPI.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }


        [Required(ErrorMessage = "Stock name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Stock name must be between 3 and 50 characters")]
        public string StockName { get; set; }


        [Required(ErrorMessage = "Stock symbol is required")]
        [RegularExpression("^[A-Za-z]{3,10}$", ErrorMessage = "Invalid stock symbol format")]
        public string StockSymbol { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<StockPrice> StockPrices { get; set; }

        public Stock() { }           
        
        public Stock(string name, string symbol)
        {
            this.StockName = name;
            this.StockSymbol = symbol;
        }
        public Stock(int id, string name, string symbol)
        {
            this.StockId = id;
            this.StockName = name;
            this.StockSymbol = symbol;
        }

        public override string ToString()
        {
            return $"{{ StockId: {StockId}, StockName: {StockName}, StockSymbol: {StockSymbol}, CreationDate: {CreationDate} }}";
        }
        public Stock(StockDTO stock)
        {
            StockId = stock.StockId;
            StockName = stock.StockName;
            StockSymbol = stock.StockSymbol;
            CreationDate = stock.CreationDate;
        }
    }
}