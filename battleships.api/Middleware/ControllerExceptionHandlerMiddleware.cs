using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace battleships.api.Middleware
{
     /// <summary>
    /// ControllerExceptionHandlerMiddleware
    /// </summary>
    public class ControllerExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ControllerExceptionHandlerMiddleware> logger;
        /// <summary>
        /// ControllerExceptionHandlerMiddleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ControllerExceptionHandlerMiddleware(RequestDelegate next, ILogger<ControllerExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // HTTP 200
                await next(context);
            }
            catch (Exception ex)
            {
                // NOT SUCCESS HTTP CODES              
                await HandleExceptionAsync(context, ex, logger);
            }
        }

        /// <summary>
        /// HandleExceptionAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ControllerExceptionHandlerMiddleware> logger)
        {
            // default is HTTP 500
            var statusCode = HttpStatusCode.InternalServerError;

            //
            // HttpStatusCodes from MSDN
            //
            // https://msdn.microsoft.com/en-us/library/system.net.httpstatuscode(v=vs.110).aspx
            //
            switch (exception)
            {
               
                case ArgumentException err:
                    logger.LogWarning("ControllerExceptionHandlerMiddleware: ArgumentException. {@exception}", err);
                    statusCode = HttpStatusCode.BadRequest;
                    break;
        
                default:
                    logger.LogError("ControllerExceptionHandlerMiddleware: Exception (Unhandled/HTTP 5xx). {@exception}", exception);
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}