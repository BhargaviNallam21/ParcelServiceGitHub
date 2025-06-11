using Newtonsoft.Json;
using System.Net;

namespace ParcelService.CutomErrorHandler
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var response = context.Response;
                response.ContentType = "application/json";
                var statusCode = ex switch
                {
                    NotFoundException => HttpStatusCode.NotFound,
                    BadRequestException => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                };
                response.StatusCode = (int)statusCode;
                var errorresponse = new
                {
                    statusCode = response.StatusCode,
                    ErrorMessage = ex.Message
                };
                await response.WriteAsync(JsonConvert.SerializeObject(errorresponse));
            }

        }
    }
}
