using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using StockMarketAPI.DataTransferObject;
using StockMarketAPI.Models;

namespace StockMarketAPI.Utils
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

            /*if (!isValid)
            {
                List<int> errorCodes = new List<int>();
                JToken errorSchema = JToken.Parse(schema.ToString());
                JToken errorMessages = errorSchema.SelectToken("$.errorMessage");

                foreach (string error in errors)
                {
                    try
                    {
                        JToken errorToken = JToken.Parse(error);
                        string errorProperty = errorToken["property"].ToString();
                        string errorMessage = errorMessages.SelectToken($"$.{errorProperty}").ToString();
                        int errorCode = int.Parse(errorMessage.Substring(errorMessage.IndexOf("[") + 1, errorMessage.IndexOf("]") - errorMessage.IndexOf("[") - 1));
                        errorCodes.Add(errorCode);

                        if (error.Contains("Invalid type. Expected String "))
                        {
                            string propertyName = error.Substring(error.LastIndexOf("Path '") + 6);
                            propertyName = propertyName.Substring(0, propertyName.IndexOf('\''));
                            int ErrorCode = 0;
                            if(propertyName.Equals("StockName"))
                            {
                                ErrorCode = 125;
                            }
                            if (propertyName.Equals("StockSymbol"))
                            {
                                ErrorCode = 126;
                            }
                            ReturnErrors.Add(ErrorMessages.Errors[ErrorCode]);
                            
                        }
                        else if (error.Contains("Invalid type. Expected Number "))
                        {
                            string propertyName = error.Substring(error.LastIndexOf("Path '") + 6);
                            propertyName = propertyName.Substring(0, propertyName.IndexOf('\''));
                            int ErrorCode = 0;
                            if (propertyName.Equals("Price"))
                            {
                                ErrorCode = 121;
                            }
                            ReturnErrors.Add(ErrorMessages.Errors[ErrorCode]);
                        }
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
            }*/

            if(!ReturnErrors.Any())
                ReturnErrors.AddRange(DataValidation.InsertionData(new StockDTO().ConvertToStockDTO(stock)));
            return ReturnErrors;
        }
    }
}

