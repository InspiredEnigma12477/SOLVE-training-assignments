namespace StockMarketAPI.Models
{
    public class StockPrice
    {
        public int StockId { get; set; }
        public double Price { get; set; }
        public DateTime AtTime { get; set; }

        public StockPrice() { }

        public StockPrice(int stockId, int price, DateTime atTime)
        {
            StockId = stockId;
            Price = price;
            AtTime = atTime;
        }
        public override string ToString()
        {
            return $"{{ {StockId}, {Price}, {AtTime} }}";
        }
    }
}
