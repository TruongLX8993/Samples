using System.Threading.Tasks;
using NUnit.Framework;
using WebApplication.Infrastructures.Data.Read;

namespace Test
{
    [TestFixture]
    public class SqliteConnectionFactoryTest
    {
        [Test]
        public async Task CreateConnectionShouldOK()
        {
            
            var factory = new SqliteReadDbConnectionFactory(@"Data source=E:\Sample-Projects\Samples\Delegate\CQRSSamples\studentmgr.sqlite;");
        }
    }
}