using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Solid.API.Middlewares
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ShabbatMiddleware> _logger;

        public ShabbatMiddleware(RequestDelegate next, ILogger<ShabbatMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestSeq = Guid.NewGuid().ToString();
            _logger.LogInformation($"Request Starts {requestSeq}");
            context.Items.Add("RequestSequence", requestSeq);

            // בדיקת התאריך הנוכחי
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                _logger.LogInformation($"Shabbat detected, service is not available");
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Service is not available on Shabbat");
                return;
            }

            await _next(context);
            _logger.LogInformation($"Request Ends {requestSeq}");
        }
    }

    public static class ShabbatMiddlewareExtensions
    {
        public static IApplicationBuilder UseShabbatMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbatMiddleware>();
        }
    }
}
