using Microsoft.AspNetCore.Mvc.Filters;
using WorkRun.BaseDb;
using WorkRun.NpgSql;

namespace WorkRun.Service
{
    public class ServiceRunFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is IServiceController controller)
            {
                WorkRunContext ctx = new NpgContext();
                controller.SetProps(ctx);
            }

            await next();
        }
    }
}
