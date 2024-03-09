using Newtonsoft.Json;
using System.Drawing.Text;
using System.Net;

namespace WebApi.ExceptionHandler
{
    public class ApiExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ApiExceptionHandler(RequestDelegate next)
        {
            _next = next;
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
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { Error = "hai something wrong" });
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);

        }

    }
}
