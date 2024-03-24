using Mc2.CrudTest.Core.Domain.Core.Exceptions;
using Mc2.CrudTest.Core.Domain.Core.Validations;
using Mc2.CrudTest.Core.Domain.Models;

namespace Mc2.CrudTest.Presentation.Server.midlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(ex, httpContext);
            }
        }

        private async Task HandleException(Exception ex, HttpContext httpContext)
        {
            if (ex is InvalidOperationException)
            {
                httpContext.Response.StatusCode = 400; //HTTP status code
                //httpContext.Response.WriteAsync("Invalid operation");
                //httpContext.Response.WriteAsync("Invalid operation");             
                await httpContext.Response.WriteAsJsonAsync(
                    Response.Create(statusCode: 400, message: "Invalid operation", isSuccess: false)
                );
            }
            else if (ex is ArgumentException)
            {
                await httpContext.Response.WriteAsync("Invalid argument");
            }
            else if (ex is CustomerValidateException)
            {
                List<ValidationError> dataError = ((CustomerValidateException)ex).GetErrors();
                await httpContext.Response.WriteAsJsonAsync(
                    Response<List<ValidationError>>.Create(dataError, 500, "Validate error", false));
            }
            else
            {
                await httpContext.Response.WriteAsync("Unknown error");
            }
        }
    }


    public static class ExceptionHandleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandleMiddleware>();
        }
    }
}