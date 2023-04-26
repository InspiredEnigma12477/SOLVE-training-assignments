using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using StockMarket.Utils;
using System.Globalization;
using StockMarket.DataAccessLayer;
using System.Windows.Forms;
using System.IO;

namespace StockMarket.Models
{
    public static class DataValidation
    {
        public static List<ErrorMessage> ValidateData(dynamic stock)
        {
            List<ErrorMessage> errors = new List<ErrorMessage>();

            if (stock.StockId < 1)
                errors.Add(ErrorMessages.Errors[100]);

            if (string.IsNullOrWhiteSpace(stock.StockName))
                errors.Add(ErrorMessages.Errors[101]);

            if (stock.StockSymbol == null || string.IsNullOrWhiteSpace(stock.StockSymbol))
            {
                errors.Add(ErrorMessages.Errors[107]);
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


            if (DbManager.IsStockExist(stock.StockSymbol))
                errors.Add(ErrorMessages.Errors[111]);

            return errors;
        }

    }
}