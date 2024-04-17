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
            var result = JsonConvert.SerializeObject(new { Error = "Something wrong" });
            context.Response.StatusCode = (int)code;
            ////_logger.LogError(exception, "An error occurred");
            LogExceptionToFile(exception);

            return context.Response.WriteAsync(result);
        }

        private void LogExceptionToFile(Exception exception)
        {
            try
            {
                string relativePath = @".\ErrorLog.txt"; // .\ represents the current directory
                string fullPath = Path.Combine(Environment.CurrentDirectory, relativePath);
                var logMessage = $"[{DateTime.Now}] Exception: {exception.Message}\nStackTrace: {exception.StackTrace}\n innerException:{exception.InnerException}";

                if (File.Exists(fullPath))
                {
                    using (var fileStream = new StreamWriter(fullPath, true)) 
                    {
                        fileStream.WriteLine(logMessage);
                    }
                }
                else
                {
                    File.AppendAllText(fullPath, logMessage);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions related to logging (e.g., disk full, permissions, etc.)
            }
        }

    }
}
