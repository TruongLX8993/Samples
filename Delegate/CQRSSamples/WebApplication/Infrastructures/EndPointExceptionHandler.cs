using System;
using WebApplication.Application.Exceptions;
using WebApplication.Infrastructures.Apis;

namespace WebApplication.Infrastructures
{
    public static class EndPointExceptionHandler
    {
        public static EndPointError GetError(Exception exception)
        {
            if (exception is RequestInvalidException)
            {
                return new EndPointError()
                {
                    Code = 1,
                    Message = exception.Message
                };
            }

            return new EndPointError()
            {
                Code = 2,
                Message = "Server internal error"
            };
        }
    }
}