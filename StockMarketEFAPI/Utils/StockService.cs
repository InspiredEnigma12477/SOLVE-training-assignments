using StockMarketEFAPI.DataAccessLayer;
using StockMarketEFAPI.Utils;
using StockMarketEFAPI.DataTransferObject;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockMarketEFAPI.Utils
{
    public static class StockService
    {
        public static object MathFunctions(int id, MathOperationDTO oprand)
        {
            using (StreamWriter writer = new StreamWriter("D:\\dtoDate.txt"))
            {
                writer.WriteLine(oprand.ToString());
            }
            string formattedDate = oprand.Date.ToString("yyyy-MM-dd");
            if (oprand == null)
            {
                return null;
            }
            switch (oprand.funName.ToUpper())
            {
                case "AVG" :
                    return new { AvgPrice = DbManager.StockByIdAvg(id, formattedDate) };
                    break;
                case "MIN":
                    return new { MinPrice = DbManager.StockByIdMin(id, formattedDate) }; ;
                    break;
                case "MAX":
                    return new { MaxPrice = DbManager.StockByIdMax(id, formattedDate) }; ;
                    break;
                default:
                    return null;
            }
            return null;
        }
    }
}
