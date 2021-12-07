using System.Collections.Generic;

namespace WebApplication.Infrastructures.Apis
{
    public class EndPointResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public IList<EndPointError> Errors { get; set; }
    }
}