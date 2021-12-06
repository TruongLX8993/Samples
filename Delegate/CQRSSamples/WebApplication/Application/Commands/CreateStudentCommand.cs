using MediatR;

namespace WebApplication.Application.Commands
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}