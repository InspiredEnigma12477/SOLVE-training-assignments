using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace StockMarket
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            // In the above WebApiConfig.Register() method, config.MapHttpAttributeRoutes() enables
            // attribute routing which we will learn later in this section. The config.Routes is a
            // route table or route collection of type HttpRouteCollection. The "DefaultApi" route
            // is added in the route table using MapHttpRoute() extension method. The MapHttpRoute()
            // extension method internally creates a new instance of IHttpRoute and adds it to an HttpRouteCollection.
            // However, you can create a new route and add it into a collection manually as shown below.

            /*
            config.MapHttpAttributeRoutes();

            IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}",
                                            new { id = RouteParameter.Optional }, null);
            config.Routes.Add("DefaultApi", defaultRoute);
            */
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
    }
}
