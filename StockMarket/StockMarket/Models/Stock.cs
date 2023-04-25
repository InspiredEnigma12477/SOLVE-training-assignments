using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StockMarket.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        [Required]
        [StringLength(20)]
        public string StockName { get; set; }
        [Required]
        [StringLength(15)]
        public string StockSymbol { get; set; }
        [Required]
        [StringLength(20)]
        public string Price { get; set; }
        [Required]
        [StringLength(20)]
        public string CreationDate { get; set; }

        public Stock()
        {
            
        }
        public Stock(int id, string name, string symbol, string price, string date)
        {
            this.StockId = id;
            this.StockName = name;
            this.StockSymbol = symbol;
            this.Price = price;
            this.CreationDate = date;

        }
        public Stock(string id, string name, string symbol, string price, string date)
        {
            this.StockId = int.Parse(id);
            this.StockName = name;
            this.StockSymbol = symbol;
            this.Price = price;
            this.CreationDate = date;

        }

    }
}