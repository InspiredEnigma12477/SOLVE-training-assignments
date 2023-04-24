using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StockMarket2.Controllers
{
    public class StockController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}
