using Microsoft.AspNetCore.Mvc.Filters;

namespace WorkRun.Service
{
    public class ServiceRunFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(context.Controller is IServiceController)

            await next();
        }
    }
}
