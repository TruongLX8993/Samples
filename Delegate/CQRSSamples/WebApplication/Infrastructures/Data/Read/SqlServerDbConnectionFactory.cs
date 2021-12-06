using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;

namespace WebApplication.Infrastructures.Data.Read
{
    public class ReadDbConnectionFactory : IReadDbConnectionFactory
    {
        private readonly string _connectionString;

        public ReadDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IDbConnection> Create()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}