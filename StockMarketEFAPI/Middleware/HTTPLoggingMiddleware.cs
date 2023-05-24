using log4net.Config;
using log4net.Core;
using log4net;
using System.Reflection;
using System.Text;

namespace StockMarketEFAPI.Middleware
{
    public class HTTPLoggingMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog _logger;

        public HTTPLoggingMiddleware()
        {
            _logger = LogManager.GetLogger(typeof(HTTPLoggingMiddleware));
        }

        public HTTPLoggingMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
        }

        public async Task InvokeAsync(HttpContext context, Func<Task> next)
        {
            _logger.Info($"Incoming request {context.Request.Method} {context.Request.Path}");

            await next();

            _logger.Info($"Outgoing response {context.Response.StatusCode}");
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
