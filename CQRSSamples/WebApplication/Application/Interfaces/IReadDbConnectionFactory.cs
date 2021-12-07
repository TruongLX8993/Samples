using System.Data;
using System.Threading.Tasks;

namespace WebApplication.Application.Interfaces
{
    public interface IReadDbConnectionFactory
    {
        public Task<IDbConnection> Create();
    }
}