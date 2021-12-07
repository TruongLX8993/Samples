namespace WebApplication.Application.Exceptions
{
    [DisplayExceptionAttr("2", "Request is not valid", true)]
    public class RequestInvalidException : ApplicationException
    {
        public RequestInvalidException(string? message) : base(message)
        {
            
        }
    }
}