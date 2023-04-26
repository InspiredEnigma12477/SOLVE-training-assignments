using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Schema;

namespace StockMarket.Utils
{
    public class SchemaValidation
    {
        /*public static Dictionary<int, string> ValidateJsonSchema(string json)
        {
            var errors = new Dictionary<int, string>();
            var schemaJson = @"
            {
                ""type"": ""object"",
                ""properties"": {
                    ""stockId"": { ""type"": ""integer"" },
                    ""stockName"": { ""type"": ""string"" },
                    ""stockSymbol"": { ""type"": ""string"" },
                    ""price"": { ""type"": ""number"",""minimum"": 0},
                    ""creationDate"": { ""type"": ""string"",""format"": ""date-time""}
                },
                ""required"": [ ""stockName"", ""stockSymbol"", ""price""],
                ""additionalProperties"": false
            }";
            var schema = JSchema.Parse(schemaJson);

            try
            {
                var jsonInput = JObject.Parse(json);
                if (!jsonInput.IsValid(schema))
                {
                    foreach (var error in jsonInput.SchemaValidationErrors)
                    {
                        int errorCode;
                        string errorMessage;
                        switch (error.Schema.Type)
                        {
                            case JSchemaType.String:
                                errorCode = 101; // Invalid string value
                                errorMessage = $"Invalid string value for property '{error.PropertyName}'";
                                break;
                            case JSchemaType.Integer:
                                errorCode = 102; // Invalid integer value
                                errorMessage = $"Invalid integer value for property '{error.PropertyName}'";
                                break;
                            case JSchemaType.Number:
                                errorCode = 103; // Invalid number value
                                errorMessage = $"Invalid number value for property '{error.PropertyName}'";
                                break;
                            default:
                                errorCode = 100; // Unknown validation error
                                errorMessage = $"Unknown validation error for property '{error.PropertyName}'";
                                break;
                        }
                        errors.Add(errorCode, errorMessage);
                    }
                }
            }
            catch (JsonReaderException ex)
            {
                errors.Add(104, "Invalid JSON format: " + ex.Message);
            }
            return errors;
        }
        */

    }
}

