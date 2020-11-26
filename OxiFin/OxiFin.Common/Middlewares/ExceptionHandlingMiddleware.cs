using OxiFin.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace OxiFin.Common.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _log;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _log = logger.CreateLogger<ExceptionHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizeException appEx)
            {
                _log.LogWarning(appEx, appEx.Message, context);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = appEx.Message }));
            }
            catch (AppBaseException appEx)
            {
                _log.LogWarning(appEx, appEx.Message, context);
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = appEx.Message }));
            }            
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Fatal Error", context);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "The system could not process your request" }));
            }
        }
    }
}
