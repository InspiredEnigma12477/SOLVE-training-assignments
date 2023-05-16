namespace StockMarketMVC.Models
{
	public class StockDto
	{
		public int StockId { get; set; }
		public string StockName { get; set; }
		public string StockSymbol { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now;
		public double Price { get; set; }
	}
}