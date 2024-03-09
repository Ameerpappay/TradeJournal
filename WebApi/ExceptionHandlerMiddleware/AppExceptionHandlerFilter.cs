using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Web.Http;
using System;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace WebApi.Error
{
    public class AppExceptionHandlerFilter :ExceptionFilterAttribute
    {
        public AppExceptionHandlerFilter() { }
        
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = factory.CreateLogger("Error");
           
            if (actionExecutedContext.Exception != null)
            {
                logger.LogInformation(actionExecutedContext.Exception.Message);
            }
            base.OnException(actionExecutedContext);
        }

        //public bool AllowMultiple => throw new NotImplementedException();

        //public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        ////public ValueTask<bool> HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        ////{
        ////    return ValueTask.FromResult(true);
        ////}
        ////var builder = WebApplication.CreateBuilder(args);

        //public void GeneralExceptionHandler()
        //{
        //    var builder = WebApplication.CreateBuilder();
        //    var app = builder.Build();

        ////    app.UseExceptionHandler(x => {
        ////        x.Run(async context => {
        ////            var exception = context.Features.Get<IExceptionHandlerFeature>()!.Error;

        ////            var details = new ApiError(StatusCodes.Status500InternalServerError, "An unexpected error occurred", exception.Message);
        ////            //{
        ////            //    ErrorCode = StatusCodes.Status500InternalServerError,
        ////            //    ErrorMessage = "An unexpected error occurred",
        ////            //    ErrorDetails = exception.Message
        ////            //};

        ////            //switch (exception)
        //////            {
        //////                case DisplayToUserException:
        //////                    details.Status = StatusCodes.Status400BadRequest;
        //////                    context.Response.Headers.Add("X-Display-To-User", exception.Message);
        //////                    break;
        //////                case ...
        //////}

        ////            //await Results.Problem(details).ExecuteAsync(context);
        ////        });
        ////    });
        //}

        //public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
