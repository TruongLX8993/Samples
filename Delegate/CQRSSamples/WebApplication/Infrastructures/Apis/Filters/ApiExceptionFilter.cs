using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication.Infrastructures.Apis.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var endPointError = EndPointExceptionHandler.GetError(exception);
            var res = new EndPointResponse()
            {
                IsSuccess = false,
                Errors = new List<EndPointError>() { endPointError }
            };
            context.Result = new ObjectResult(res);
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}