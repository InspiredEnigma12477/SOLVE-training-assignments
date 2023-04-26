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
        /*public static readonly List<ErrorMessage> Errors = new List<ErrorMessage>
        {
            new ErrorMessage { Code = 100, Message = "Invalid StockId, StockId should be greater than zero." },
            new ErrorMessage { Code = 101, Message = "Stock name cannot be empty." },
            new ErrorMessage { Code = 102, Message = "Stock name must be between 3 and 50 characters." },
            new ErrorMessage { Code = 103, Message = "Stock symbol is required." },
            new ErrorMessage { Code = 104, Message = "Invalid stock symbol format. Stock symbol should be 3 to 10 alphabetic characters." },
            new ErrorMessage { Code = 105, Message = "Price is required." },
            new ErrorMessage { Code = 106, Message = "Price must be between 0.01 and 1000000." },
            new ErrorMessage { Code = 107, Message = "Creation date is required." },
            new ErrorMessage { Code = 108, Message = "Creation date must be in the format 'yyyy-MM-ddTHH:mm:ss'." },
            new ErrorMessage { Code = 109, Message = "Stock with this StockId does not exist." },
            new ErrorMessage { Code = 110, Message = "Stock with this StockName already exists." },
            new ErrorMessage { Code = 111, Message = "Stock with this StockSymbol already exists." },
            new ErrorMessage { Code = 112, Message = "Invalid input format. Please check input and try again." },
            new ErrorMessage { Code = 113, Message = "An internal server error occurred. Please try again later." },
            new ErrorMessage { Code = 114, Message = "Authorization failed. Please provide valid authentication credentials." },
            new ErrorMessage { Code = 115, Message = "Access denied. You do not have permission to access this resource." },
            new ErrorMessage { Code = 116, Message = "Invalid request method. Please check method and try again." },
            new ErrorMessage { Code = 117, Message = "Invalid input parameter. Please check input and try again." },
            new ErrorMessage { Code = 118, Message = "Required header is missing. Please check headers and try again." },
            new ErrorMessage { Code = 119, Message = "Invalid header value. Please check headers and try again." },
            new ErrorMessage { Code = 120, Message = "StockSymbol is null or whitespace value." },
        };*/

        public static readonly Dictionary<int, ErrorMessage> Errors = new Dictionary<int, ErrorMessage>
        {
            { 100, new ErrorMessage { Code = 100, Message = "Invalid StockId, StockId should be greater than zero." } },
            { 101, new ErrorMessage { Code = 101, Message = "Stock name cannot be empty." } },
            { 102, new ErrorMessage { Code = 102, Message = "Stock name must be between 3 and 50 characters." } },
            { 103, new ErrorMessage { Code = 103, Message = "Stock symbol is required." } },
            { 104, new ErrorMessage { Code = 104, Message = "Invalid stock symbol format. Stock symbol should be 3 to 10 alphabetic characters." } },
            { 105, new ErrorMessage { Code = 105, Message = "Price is required." } },
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
            { 120, new ErrorMessage { Code = 120, Message = "StockSymbol is null or whitespace value." } },
        };
    }

}