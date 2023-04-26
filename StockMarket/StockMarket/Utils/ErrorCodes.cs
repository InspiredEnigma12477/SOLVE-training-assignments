using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMarket.Utils
{
    public static class ErrorCodes
    {
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int ServerError = 500;
        public const int DatabaseError = 502;
        public const int DatabaseConnectionError = 503;
        public const int DatabaseSchemaError = 505;
        // Add more error codes as needed

        public static Dictionary<int, string> Messages = new Dictionary<int, string>()
        {
            { BadRequest, "Bad Request" },
            { Unauthorized, "Unauthorized" },
            { Forbidden, "Forbidden" },
            { NotFound, "Not Found" },
            { ServerError, "Server Error" },
            { DatabaseError, "Database Error" },
            { DatabaseConnectionError, "Database Connection Error" },
            { DatabaseSchemaError, "Database Schema Error" }
            // Add more error messages as needed
        };
    }
}