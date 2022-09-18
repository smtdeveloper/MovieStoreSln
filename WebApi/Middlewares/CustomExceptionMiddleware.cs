using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
       private readonly RequestDelegate _next;
       private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {

                string message = " [Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                // Console.WriteLine(message);
                _loggerService.Write(message);
                await _next(context);
                watch.Stop();

                message = "[Response] HTTP  " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " 'in " + watch.Elapsed.TotalMilliseconds + " ms";
                //Console.WriteLine(message);
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }


        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + "Eror Message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            // Console.WriteLine(message);
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);

            return context.Response.WriteAsync(result);

        }

    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();

        }
    }
}
