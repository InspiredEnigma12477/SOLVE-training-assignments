using StockMarket.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockMarket.DataTransferObject
{
    public class StockDTO
    {
        public int StockId { get; set; }
        
        public string StockName { get; set; }
        
        public string StockSymbol { get; set; }
        
        public double Price { get; set; }
        
        public DateTime CreationDate { get; set;  }
    }
}