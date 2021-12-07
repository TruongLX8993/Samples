using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApplication.Application.Repositories;
using WebApplication.Domain.Entities.StudentAggregate;

namespace WebApplication.Application.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                Name = request.Name
            };
            _unitOfWork.Begin();
            await _unitOfWork.GetRepository<int, Student>()
                .Save(student);
            await _unitOfWork.Commit();
            return true;
        }
    }
}