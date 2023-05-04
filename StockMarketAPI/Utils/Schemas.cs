using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMarketAPI.Utils
{
    public static class Schemas
    {
        public static readonly string JSONInsertSchema = @"{
        ""$schema"": ""http://json-schema.org/draft-07/schema#"",
        ""type"": ""object"",
        ""properties"": {
            ""StockName"": {
                    ""type"": ""string"",
                    ""errorMessage"": {
                        ""required"": {""errorCode"": 101 },
                        ""type"": {""errorCode"": 125}
                    }
                },
            ""StockSymbol"": {
                    ""type"": ""string"",
                    ""errorMessage"": {
                        ""required"": {""errorCode"": 101 },
                        ""type"": {""errorCode"": 126}
                    }
                },
            ""Price"": {
                ""type"": ""number"",
                ""errorMessage"": {
                    ""required"": {""errorCode"": 105 },
                    ""type"": {""errorCode"": 121}
                }
            }
        },
        ""required"": [ ""StockName"", ""StockSymbol"", ""Price"" ]
    }";

        public static readonly string JSONInsertNewSchema = @"{
            ""$schema"": ""http://json-schema.org/draft-07/schema#"",
            ""type"": ""object"",
            ""properties"": {
                ""StockName"": {
                    ""type"": ""string""
                },
                ""StockSymbol"": {
                    ""type"": ""string""
                }
            },
            ""required"": [""StockName"", ""StockSymbol""],
            ""errorMessage"": {
                ""required"": {
                    ""StockName"": {""enum"": [101]},
                    ""StockSymbol"": {""enum"": [102]}
                },
                ""type"": {
                    ""StockName"": {""enum"": [125]},
                    ""StockSymbol"": {""enum"": [126]}
                }
            }
        }
        ";

    }
}