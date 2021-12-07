
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Shared.Models;

namespace WebApplication.Application.Queries
{
    public class
        GetStudentWithAveScoreQueryHandler : IRequestHandler<GetStudentWithAveScoreQuery,
            Pagination<GetStudentWithAveScoreDTO>>
    {
        private readonly IReadDbConnectionFactory _readDbConnectionFactory;

        public GetStudentWithAveScoreQueryHandler(IReadDbConnectionFactory readDbConnectionFactory)
        {
            _readDbConnectionFactory = readDbConnectionFactory;
        }

        public async Task<Pagination<GetStudentWithAveScoreDTO>> Handle(
            GetStudentWithAveScoreQuery request, CancellationToken cancellationToken)
        {
            var cmd = $@"select name as Name from Student where name like '%{request.Keyword}%";
            using (var dbConnection = await _readDbConnectionFactory.Create())
            {
                var res = await dbConnection.QueryAsync<GetStudentWithAveScoreDTO>(cmd);
                return new Pagination<GetStudentWithAveScoreDTO>()
                {
                };
            }
        }
    }
}