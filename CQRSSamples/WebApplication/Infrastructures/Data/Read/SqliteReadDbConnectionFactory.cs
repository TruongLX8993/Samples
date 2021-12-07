using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using WebApplication.Application.Interfaces;

namespace WebApplication.Infrastructures.Data.Read
{
    public class SqliteReadDbConnectionFactory : IReadDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqliteReadDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> Create()
        {
            var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}