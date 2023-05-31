using StockMarketAPI.DataAccessLayer;
using StockMarketAPI.Utils;
using StockMarketAPI.DataTransferObject;
using static System.Runtime.InteropServices.JavaScript.JSType;
using StockMarketAPI.Models;

namespace StockMarketAPI.Utils
{
    public static class StockService
    {
        public static object MathFunctionsWithDate(int id, MathOperationDTO oprand)
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
            try
            {
                switch (oprand.funName.ToUpper())
                {
                    case "AVG":
                        return new { AvgPrice = DbManager.StockByIdAvg(id, formattedDate) };
                        break;
                    case "MIN":
                        return new { MinPrice = DbManager.StockByIdMin(id, formattedDate) };
                        break;
                    case "MAX":
                        return new { MaxPrice = DbManager.StockByIdMax(id, formattedDate) };
                        break;
                    case "ALL":
                        return new
                        {
                            AvgPrice = DbManager.StockByIdAvg(id, formattedDate),
                            MinPrice = DbManager.StockByIdMin(id, formattedDate),
                            MaxPrice = DbManager.StockByIdMax(id, formattedDate)
                        };
                        break;
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return ErrorMessages.Errors[130];
            }
            return null;
        }
        public static object MathFunctions(int id, MathOperationDTO oprand)
        {
            using (StreamWriter writer = new StreamWriter("D:\\dtoDate.txt"))
            {
                writer.WriteLine(oprand.ToString());
            }
            if (oprand == null)
            {
                return null;
            }
            try
            {
                switch (oprand.funName.ToUpper())
                {
                    case "AVG":
                        return new { AvgPrice = DbManager.StockByIdAvg(id) };
                        break;
                    case "MIN":
                        return new { MinPrice = DbManager.StockByIdMin(id) };
                        break;
                    case "MAX":
                        return new { MaxPrice = DbManager.StockByIdMax(id) };
                        break;
                    case "ALL":
                        return new
                        {
                            AvgPrice = DbManager.StockByIdAvg(id),
                            MinPrice = DbManager.StockByIdMin(id),
                            MaxPrice = DbManager.StockByIdMax(id)
                        };
                        break;
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return ErrorMessages.Errors[130];
            }
            return null;
        }
    }
}
