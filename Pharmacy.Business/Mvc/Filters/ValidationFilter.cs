using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pharmacy.Core.DataTransferObjects;

namespace Pharmacy.Business.Mvc.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                                    .Where(x => x.Value.Errors.Any())
                                    .ToDictionary(x => x.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                                    .ToArray();
               
                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}