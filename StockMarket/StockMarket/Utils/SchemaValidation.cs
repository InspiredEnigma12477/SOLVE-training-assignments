using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Schema;
using Microsoft.AspNetCore.Mvc;
using StockMarket.DataTransferObject;
using StockMarket.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.IO;

namespace StockMarket.Utils
{
    public class SchemaValidation
    {
        public static List<ErrorMessage> ValidateJsonSchema(JObject stock)
        {
            List<ErrorMessage> ReturnErrors = new List<ErrorMessage>();

            string jsonString = JsonConvert.SerializeObject(stock);
            JSchema schema = JSchema.Parse(Schemas.JSONInsertNewSchema);

            JObject json = JObject.Parse(jsonString);
            bool isValid = json.IsValid(schema, out IList<string> errors);

            
            //bool isValid1 = json.IsValid(schema, out IList<string> errors123);

            

            if (!isValid)
            {
                List<int> errorCodes = new List<int>();
                JToken errorSchema = JToken.Parse(schema.ToString());
                JToken errorMessages = errorSchema.SelectToken("$.errorMessage");

                foreach (string error in errors)
                {
                    /*JToken errorToken = JToken.Parse(error);
                    string errorProperty = errorToken["property"].ToString();
                    string errorMessage = errorMessages.SelectToken($"$.{errorProperty}").ToString();
                    int errorCode = int.Parse(errorMessage.Substring(errorMessage.IndexOf("[") + 1, errorMessage.IndexOf("]") - errorMessage.IndexOf("[") - 1));
                    errorCodes.Add(errorCode);*/
                    try
                    {
                        JToken errorToken = JToken.Parse(error);
                        string errorProperty = errorToken["property"].ToString();
                        string errorMessage = errorMessages.SelectToken($"$.{errorProperty}").ToString();
                        int errorCode = int.Parse(errorMessage.Substring(errorMessage.IndexOf("[") + 1, errorMessage.IndexOf("]") - errorMessage.IndexOf("[") - 1));
                        errorCodes.Add(errorCode);
                    }
                    catch (Newtonsoft.Json.JsonReaderException)
                    {
                        errorCodes.Add(136); // Add an error code for invalid JSON data
                    }
                }

                foreach (int errorCode in errorCodes)
                {
                    ReturnErrors.Add(ErrorMessages.Errors[errorCode]);
                }
            }
            using (StreamWriter writer = new StreamWriter("D:\\error1.txt"))
            {
                foreach(ErrorMessage error in ReturnErrors)
                {
                    writer.WriteLine(error.ToString());
                }
            }
            return ReturnErrors;
        }
    }
}

