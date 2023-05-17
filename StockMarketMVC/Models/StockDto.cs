namespace StockMarketMVC.Models
{
	public class StockDto
	{
		public int StockId { get; set; }
		public string StockName { get; set; }
		public string StockSymbol { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now;
	}

	public class StockInsertDto{
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
    }
    public class StockUpdateDto
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
    }
}