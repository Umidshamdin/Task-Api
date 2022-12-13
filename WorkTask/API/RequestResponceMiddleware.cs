using NLog;
using ILogger = NLog.ILogger;

namespace API
{
    public class RequestResponceMiddleware
    {
        private readonly RequestDelegate next;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public RequestResponceMiddleware(RequestDelegate Next)
        {
            next = Next;        
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var originBody = httpContext.Response.Body;
            try
            {
                //request
                var memStream = new MemoryStream();
                httpContext.Response.Body = memStream;
                await next(httpContext).ConfigureAwait(false);
                _logger.Info("request success");
                //request
                
                memStream.Position = 0;
                var responseBody = new StreamReader(memStream).ReadToEnd();
                _logger.Info("responce" + "" + responseBody);
                var memoryStreamModified = new MemoryStream();
                var sw = new StreamWriter(memoryStreamModified);
                sw.Write(responseBody); 
                sw.Flush();
                memoryStreamModified.Position = 0;
                await memoryStreamModified.CopyToAsync(originBody).ConfigureAwait(false);
            }
            finally
            {
                httpContext.Response.Body = originBody;
            }
        }
    }
}
