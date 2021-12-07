using Microsoft.AspNetCore.Mvc;
using WebApplication.Infrastructures.Apis.Filters;

namespace WebApplication.Infrastructures.Apis.Controllers
{
    [ApiController]
    [ApiExceptionFilter]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult SendResult(object data)
        {
            var apiRes = new EndPointResponse
            {
                IsSuccess = true,
                Data = data
            };
            return Ok(apiRes);
        }
    }
}