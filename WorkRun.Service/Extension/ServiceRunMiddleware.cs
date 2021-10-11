namespace WorkRun.Service
{
    public class ServiceRunMiddleware
    {
        private readonly RequestDelegate _next;
        public ServiceRunMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path=="/emre" & httpContext.Request.Query["w"] == "3")
            {
                await httpContext.Response.WriteAsync("My Middleware");
            }
            await _next.Invoke(httpContext);
        }
    }
}
