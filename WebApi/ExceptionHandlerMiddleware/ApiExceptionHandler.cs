using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Net;

namespace WebApi.ExceptionHandler
{
    public class ApiExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionHandler> _logger; // Injected logger

        public ApiExceptionHandler(RequestDelegate next, ILogger<ApiExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { Error = "hai something wrong" });
            context.Response.StatusCode = (int)code;
            _logger.LogError(exception, "An error occurred");

            return context.Response.WriteAsync(result);

        }
    }
}
