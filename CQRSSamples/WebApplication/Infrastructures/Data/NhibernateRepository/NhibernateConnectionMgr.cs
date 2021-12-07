using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace WebApplication.Infrastructures.Data.NhibernateRepository
{
    public class NhibernateConnectionMgr
    {
        private ISessionFactory _sessionFactory;
        private readonly string _connectionString;

        public NhibernateConnectionMgr(string connectionString)
        {
            _connectionString = connectionString;
            Init();
        }

        private void Init()
        {
            var cfg = SQLiteConfiguration.Standard
                .ConnectionString(c =>
                    c.Is(_connectionString));

            _sessionFactory = Fluently.Configure()
                .Database(
                    cfg
                )
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public ISession CreateSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}