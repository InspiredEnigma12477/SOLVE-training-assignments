namespace StockMarketAPI.Models
{
    public class StockPrice
    {
        int StockId { get; set; }
        public int Price { get; set; }
        public DateTime AtTime { get; set; }

        public StockPrice() { }

        public StockPrice(int stockId, int price, DateTime atTime)
        {
            StockId = stockId;
            Price = price;
            AtTime = atTime;
        }
    }
}
