namespace StockMarketMVC.Models
{
    public class StockViewModel
    {
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
