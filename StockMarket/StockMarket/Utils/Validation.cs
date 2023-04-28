using Newtonsoft.Json.Linq;
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
        public static List<ErrorMessage> ValidateStock(JObject stock)
        {
            List<ErrorMessage> errors = new List<ErrorMessage>();
            errors.AddRange(SchemaValidation.ValidateJsonSchema(stock));
            errors.AddRange(DataValidation.InsertionData(new StockDTO().ConvertToStockDTO(stock)));

            return errors;
        }
    }
}