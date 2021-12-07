using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication.Application.Exceptions;

namespace WebApplication.Infrastructures.Apis.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var endPointError = GetError(exception);
            if (endPointError == null)
            {
                context.Result = new ObjectResult("Server internal error")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            var res = new EndPointResponse()
            {
                IsSuccess = false,
                Errors = new List<EndPointError>() { endPointError }
            };
            context.Result = new ObjectResult(res);
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }

        private static EndPointError GetError(Exception exception)
        {
            if (exception.GetType()
                .GetCustomAttributes(typeof(DisplayExceptionAttr), true)
                .FirstOrDefault() is not DisplayExceptionAttr attr)
            {
                return null;
            }

            return new EndPointError()
            {
                Code = attr.Code,
                Message = attr.Message,
                InnerMessage = attr.ShowMessageException ? exception.Message : string.Empty
            };
        }
    }
}