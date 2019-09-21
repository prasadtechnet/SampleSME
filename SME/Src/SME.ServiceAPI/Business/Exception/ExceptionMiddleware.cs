using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Exception
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }



        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Something went wrong:{ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
               
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, System.Exception exception)
        {
            var exceptionType = exception.GetType();
            HttpStatusCode statusCode;
            var message="";

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if(exceptionType == typeof(AuthenticateException))
            {
               // message = LoggerHelper.GetExceptionDetails(exception);
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                statusCode = HttpStatusCode.NotImplemented;
            }
            else
            {
                message = "Unauthorized Access";
                statusCode = HttpStatusCode.InternalServerError;
            }
            httpContext.Response.StatusCode =(int)statusCode;
            //return httpContext.Response.WriteAsync((new ErrorDetails
            //{               
            //    Errors = new[] { message }
            //}).ToString());

            return httpContext.Response.WriteAsync( message);
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }

    internal class AuthenticateException
    {
    }
}
