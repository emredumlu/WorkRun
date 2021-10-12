using Microsoft.AspNetCore.Mvc.Filters;
using WorkRun.BaseDb;
using WorkRun.MariaSql;
using WorkRun.NpgSql;

namespace WorkRun.Service
{
    public class ServiceRunFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is IServiceController controller)
            {
                var dbKey = context.HttpContext.Request.Headers["db-type"];

                WorkRunContext ctx = dbKey == "1" ? new NpgContext() : new MariaContext();
                controller.SetProps(ctx);
            }

            await next();
        }
    }
}
