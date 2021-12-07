using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Application.Commands;

namespace WebApplication.Infrastructures.Apis.Controllers
{
    [Route("/api/student")]
    public class StudentController : BaseApiController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            var res = await _mediator.Send(command);
            return SendResult(res);
        }
    }
}