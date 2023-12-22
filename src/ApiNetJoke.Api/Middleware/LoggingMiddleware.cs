using System.Text.Json;

namespace ApiNetJoke.Api.Middleware
{
    public class LoggingMiddleware
    {
        private RequestDelegate _next;
        private ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBody = context.Response.Body;
            var newBody = new MemoryStream();
            context.Response.Body = newBody;
            var bodyText = string.Empty;
            try
            {
                await _next(context);
            }
            finally
            {
                newBody.Seek(0, SeekOrigin.Begin);
                bodyText = await new StreamReader(newBody).ReadToEndAsync();
                Console.WriteLine($"LoggingMiddleware: {bodyText}");
                newBody.Seek(0, SeekOrigin.Begin);
                await newBody.CopyToAsync(originalBody);
            }

            var requestLog = new RequestLog
            {
                RequestMethod = context.Request.Method,
                RequestPath = context.Request.Path,
                QueryString = context.Request.QueryString.ToString(),
                StatusCode = context.Response.StatusCode,
                ResponseBody = bodyText,
                // Add more properties as needed
            };

            var serializedLog = JsonSerializer.Serialize(requestLog);
            _logger.LogInformation(serializedLog);

        }
    }

}
