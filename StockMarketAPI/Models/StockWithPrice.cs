using StockMarketAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace StockMarketAPI.Models
{
    public class StockWithPrice
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public double? StockPrice { get; set; }
        public DateTime CreationDate { get; set; }

        public StockWithPrice()
        {
            
        }

    }
}
