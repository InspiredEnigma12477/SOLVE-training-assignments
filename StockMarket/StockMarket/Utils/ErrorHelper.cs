using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;

namespace StockMarket.Utils
{
    public static class ErrorHelper
    {
        public static HttpResponseMessage GetErrorResponse(int errorCode, string errorMessage)
        {
            HttpResponseMessage response = new HttpResponseMessage((HttpStatusCode)errorCode);
            response.Content = new StringContent(errorMessage);
            return response;
        }

        public static HttpResponseMessage GetErrorResponse(int errorCode)
        {
            string errorMessage;
            if (ErrorCodes.Messages.TryGetValue(errorCode, out errorMessage))
            {
                return GetErrorResponse(errorCode, errorMessage);
            }
            else
            {
                return GetErrorResponse(ErrorCodes.ServerError, "An unexpected error occurred.");
            }
        }
    }
}