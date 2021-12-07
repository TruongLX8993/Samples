using System;

namespace WebApplication.Application.Exceptions
{
    public class DisplayExceptionAttr : Attribute
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool ShowMessageException { get; set; }

        public DisplayExceptionAttr(string code, string message, bool showMessageException)
        {
            Code = code;
            Message = message;
            ShowMessageException = showMessageException;
        }
    }
}