using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace StockMarket.Utils
{
    public class ErrorMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return $"Code: {Code}, Message: {Message}";
        }
    }

    public static class ErrorMessages
    {
        public static readonly Dictionary<int, ErrorMessage> Errors = new Dictionary<int, ErrorMessage>
        {
            { 100, new ErrorMessage { Code = 100, Message = "Invalid StockId, StockId should be greater than zero." } },
            { 101, new ErrorMessage { Code = 101, Message = "Stock name cannot be empty." } },
            { 102, new ErrorMessage { Code = 102, Message = "Stock name must be between 3 and 50 characters." } },
            { 103, new ErrorMessage { Code = 103, Message = "Stock symbol is required." } },
            { 104, new ErrorMessage { Code = 104, Message = "Invalid stock symbol format. Stock symbol should be 3 to 10 alphabetic characters." } },
            { 105, new ErrorMessage { Code = 105, Message = "Price is required field." } },
            { 106, new ErrorMessage { Code = 106, Message = "Price must be between 0.01 and 1000000." } },
            { 107, new ErrorMessage { Code = 107, Message = "Creation date is required." } },
            { 108, new ErrorMessage { Code = 108, Message = "Creation date must be in the format 'yyyy-MM-ddTHH:mm:ss'." } },
            { 109, new ErrorMessage { Code = 109, Message = "Stock with this StockId does not exist." } },
            { 110, new ErrorMessage { Code = 110, Message = "Stock with this StockName already exists." } },
            { 111, new ErrorMessage { Code = 111, Message = "Stock with this StockSymbol already exists." } },
            { 112, new ErrorMessage { Code = 112, Message = "Invalid input format. Please check input and try again." } },
            { 113, new ErrorMessage { Code = 113, Message = "An internal server error occurred. Please try again later." } },
            { 114, new ErrorMessage { Code = 114, Message = "Authorization failed. Please provide valid authentication credentials." } },
            { 115, new ErrorMessage { Code = 115, Message = "Access denied. You do not have permission to access this resource." } },
            { 116, new ErrorMessage { Code = 116, Message = "Invalid request method. Please check method and try again." } },
            { 117, new ErrorMessage { Code = 117, Message = "Invalid input parameter. Please check input and try again." } },
            { 118, new ErrorMessage { Code = 118, Message = "Required header is missing. Please check headers and try again." } },
            { 119, new ErrorMessage { Code = 119, Message = "Invalid header value. Please check headers and try again." } },
            { 120, new ErrorMessage { Code = 120, Message = "StockSymbol cannot be null." } },
            { 121, new ErrorMessage { Code = 121, Message = "Price is must be of double type." } },
            { 122, new ErrorMessage { Code = 122, Message = "Stock symbol cannot be empty." } },
            { 123, new ErrorMessage { Code = 123, Message = "StockName cannot be null." } },
            { 124, new ErrorMessage { Code = 124, Message = "Required property \"StockName\", \"StockSymbol\", \"Price\" not found in JSON." } },
            { 125, new ErrorMessage { Code = 125, Message = "StockName should be string." } },
            { 126, new ErrorMessage { Code = 126, Message = "StockSymbol should be string." } },
            { 127, new ErrorMessage { Code = 127, Message = "Invalid format for property '{propertyName}'. Expected format: {expectedFormat}." } },
            { 128, new ErrorMessage { Code = 128, Message = "Property '{propertyName}' is not allowed." } },
            { 129, new ErrorMessage { Code = 129, Message = "'{propertyName}' must be a positive number." } },
            { 130, new ErrorMessage { Code = 130, Message = "'{propertyName}' must be a non-negative number." } },
            { 131, new ErrorMessage { Code = 131, Message = "'{propertyName}' must be a string." } },
            { 132, new ErrorMessage { Code = 132, Message = "'{propertyName}' must be an email address." } },
            { 133, new ErrorMessage { Code = 133, Message = "'{propertyName}' must be a valid URL." } },
            { 134, new ErrorMessage { Code = 134, Message = "'{propertyName}' must be a valid date in the format '{dateFormat}'." } },
            { 135, new ErrorMessage { Code = 135, Message = "'{propertyName}' must be a boolean value (true or false)." } },
            { 136, new ErrorMessage { Code = 136, Message = "Invalid JSON data" } },

        };
    }

}