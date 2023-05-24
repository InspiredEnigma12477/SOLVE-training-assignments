using Newtonsoft.Json.Linq;
namespace StockMarketEFAPI.Utils
{
    public class Validation
    {
        public static List<ErrorMessage> ValidateStock(JObject stock)
        {
            return SchemaValidation.ValidateJsonSchema(stock);  
        }
    }
}