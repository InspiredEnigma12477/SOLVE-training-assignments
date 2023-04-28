using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace StockMarket.Models
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
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1000000")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Creation date is required")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Stock()
        {
            
        }
        public Stock(int id, string name, string symbol, double price)
        {
            this.StockId = id;
            this.StockName = name;
            this.StockSymbol = symbol;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"StockId: {StockId}, StockName: {StockName}, StockSymbol: {StockSymbol}, Price: {Price}, CreationDate: {CreationDate}";
        }

    }
}