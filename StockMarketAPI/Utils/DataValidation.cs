using StockMarketAPI.Utils;
using StockMarketAPI.DataAccessLayer;
using StockMarketAPI.DataTransferObject;

namespace StockMarketAPI.Models
{
    public class DataValidation
    {
        private static List<ErrorMessage> errors = new List<ErrorMessage>();
        private static StockDTO checkStock = null;
        /*public static List<ErrorMessage> ValidateData(StockDTO stock)
        {
            if (stock.StockId < 1)
                errors.Add(ErrorMessages.Errors[100]);

            if (stock.StockName == null)
            {
                errors.Add(ErrorMessages.Errors[123]);
            }
            else if (string.IsNullOrWhiteSpace(stock.StockName))
            {
                errors.Add(ErrorMessages.Errors[101]);
            }

            if (stock.StockSymbol == null)
            {
                errors.Add(ErrorMessages.Errors[120]);
            }
            else if (string.IsNullOrWhiteSpace(stock.StockSymbol))
            {
                errors.Add(ErrorMessages.Errors[122]);
            }
            else
            {
                if (!RegexPatterns.StockTickerSymbol.IsMatch(stock.StockSymbol))
                {
                    errors.Add(ErrorMessages.Errors[104]);
                }
            }

            if (stock.Price == null)
                errors.Add(ErrorMessages.Errors[105]);

            if (stock.Price < 0)
                errors.Add(ErrorMessages.Errors[106]);


            if (DbManager.IsStockSymbolExist(stock.StockSymbol))
                errors.Add(ErrorMessages.Errors[111]);

            if (DbManager.IsStockNameExist(stock.StockName))
                errors.Add(ErrorMessages.Errors[110]);

            return errors;
        }*/

        public static List<ErrorMessage> InsertionData(StockDTO stock)
        {
            checkStock = stock;
            errors.Clear();

            StockName();
            StockSymbol();
            //Price();

            return errors;
        }
        public static List<ErrorMessage> UpdationData(StockDTO stock)
        {
            checkStock = stock;
            errors.Clear();

            StockId();
            StockName();
            StockSymbol();
            //Price();

            return errors;
        }

        public static void StockId()
        {
            if (checkStock.StockId < 1)
                errors.Add(ErrorMessages.Errors[100]);
        }

        public static void StockName()
        {
            if (checkStock.StockName == null)
            {
                errors.Add(ErrorMessages.Errors[123]);
            }
            else if (string.IsNullOrWhiteSpace(checkStock.StockName))
            {
                errors.Add(ErrorMessages.Errors[101]);
            }
            else if (DbManager.IsStockNameExist(checkStock.StockName))
                errors.Add(ErrorMessages.Errors[110]);
        }

        public static void StockSymbol()
        {
            if (checkStock.StockSymbol == null)
            {
                errors.Add(ErrorMessages.Errors[120]);
            }
            else if (string.IsNullOrWhiteSpace(checkStock.StockSymbol))
            {
                errors.Add(ErrorMessages.Errors[122]);
            }
            else
            {
                if (!RegexPatterns.StockTickerSymbol.IsMatch(checkStock.StockSymbol))
                {
                    errors.Add(ErrorMessages.Errors[104]);
                }
            }
            if (DbManager.IsStockSymbolExist(checkStock.StockSymbol))
                errors.Add(ErrorMessages.Errors[111]);
        }

        public static void Price()
        {
            //if (checkStock.Price == null)
                //errors.Add(ErrorMessages.Errors[105]);
/*            if (checkStock.Price < 0)
                errors.Add(ErrorMessages.Errors[106]);*/
        }

        public static List<ErrorMessage> ValidateData1(Stock stock)
        {
            List<ErrorMessage> errors = new List<ErrorMessage>();

            errors.Add(stock.StockId < 1 ? ErrorMessages.Errors[100] : null);

            errors.Add(stock.StockName == null ? ErrorMessages.Errors[123] :
                       string.IsNullOrWhiteSpace(stock.StockName) ? ErrorMessages.Errors[101] :
                       null);

            errors.Add(stock.StockSymbol == null ? ErrorMessages.Errors[120] :
                       string.IsNullOrWhiteSpace(stock.StockSymbol) ? ErrorMessages.Errors[122] :
                       !RegexPatterns.StockTickerSymbol.IsMatch(stock.StockSymbol) ? ErrorMessages.Errors[104] :
                       null);

            /*errors.Add(stock.Price == null || stock.Price < 0 ? ErrorMessages.Errors[105] : null);
            errors.Add(stock.Price < 0 ? ErrorMessages.Errors[106] : null);*/

            errors.Add(DbManager.IsStockSymbolExist(stock.StockSymbol) ? ErrorMessages.Errors[111] : null);
            errors.Add(DbManager.IsStockNameExist(stock.StockName) ? ErrorMessages.Errors[110] : null);

            return errors.Where(e => e != null).ToList();
        }


    }
}