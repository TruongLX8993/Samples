using MediatR;
using WebApplication.Application.Shared.Models;

namespace WebApplication.Application.Queries
{
    public class GetStudentWithAveScoreQuery : IRequest<Pagination<GetStudentWithAveScoreDTO>>
    {
        public string Keyword { get; set; }
    }
}