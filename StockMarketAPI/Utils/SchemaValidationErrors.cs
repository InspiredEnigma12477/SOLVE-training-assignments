using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMarket.Utils
{
    public class SchemaValidationErrors
    {
        private readonly Dictionary<int, string> _errors;

        public SchemaValidationErrors()
        {
            _errors = new Dictionary<int, string>();
        }

        public bool HasErrors => _errors.Count > 0;

        public void AddError(int errorCode, string errorMessage)
        {
            _errors[errorCode] = errorMessage;
        }

        public Dictionary<int, string> GetErrors()
        {
            return new Dictionary<int, string>(_errors);
        }
    }

}