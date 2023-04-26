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
        public static List<ErrorMessage> ValidateStock(Stock stock)
        {
            using (StreamWriter writer = new StreamWriter("D:\\trail5_error.txt"))
            {
                
                    writer.WriteLine(stock.ToString());
         
            }
            return DataValidation.ValidateData(stock);
        }
    }
}