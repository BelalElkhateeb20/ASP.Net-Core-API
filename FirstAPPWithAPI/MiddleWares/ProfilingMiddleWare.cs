using System.Diagnostics;

namespace FirstAPPWithAPI.MiddleWares
{
    public class ProfilingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleWare> logger;

        public ProfilingMiddleWare(RequestDelegate next,ILogger<ProfilingMiddleWare>logger)
        {
            this._next = next;// move the Excution To the next MiddleWare
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            logger.LogInformation($"Request'{context.Request.Path} took {stopwatch.ElapsedMilliseconds}ms to excute'");
        }
    }
}
