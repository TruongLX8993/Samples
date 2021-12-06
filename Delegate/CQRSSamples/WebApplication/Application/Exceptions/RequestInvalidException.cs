namespace WebApplication.Application.Exceptions
{
    public class RequestInvalidException : ApplicationException
    {
        public RequestInvalidException(string? message) : base(message)
        {
        }
    }
    
}