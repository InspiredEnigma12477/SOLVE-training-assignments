using System.ComponentModel.DataAnnotations;
using StockMarketAPI.DataTransferObject;

namespace StockMarketAPI.Models
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


        /*[Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1000000")]
        public double Price { get; set; }*/

        public DateTime CreationDate { get; set; } = DateTime.Now;

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
            return $"StockId: {StockId}, StockName: {StockName}, StockSymbol: {StockSymbol}, CreationDate: {CreationDate}";
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