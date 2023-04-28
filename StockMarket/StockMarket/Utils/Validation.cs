using StockMarket.DataTransferObject;
using StockMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StockMarket.Utils
{
    public class Validation
    {
        public static List<ErrorMessage> ValidateStock(StockDTO stock)
        {            
            return DataValidation.InsertionData(stock);
        }
    }
}