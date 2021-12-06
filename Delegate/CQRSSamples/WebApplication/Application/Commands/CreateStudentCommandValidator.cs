using FluentValidation;

namespace WebApplication.Application.Commands
{
    public class CreateStudentCommandValidator :
        AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty();
        }
    }
}