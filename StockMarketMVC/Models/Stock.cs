namespace StockMarketMVC.Models
{
	public class Stock
	{
		public int StockId { get; set; }
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
	}
}