using MediatR;

namespace WebApplication.Application.Commands
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        
    }
}