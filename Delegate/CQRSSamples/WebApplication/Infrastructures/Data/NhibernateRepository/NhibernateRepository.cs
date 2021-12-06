using System.Threading.Tasks;
using NHibernate;
using WebApplication.Application.Repositories;

namespace WebApplication.Infrastructures.Data.NhibernateRepository
{
    public class NhibernateRepository<TKey, TEntity> : IRepository<TKey, TEntity>
    {
        private readonly ISession _session;

        public NhibernateRepository(ISession session)
        {
            _session = session;
        }

        public async Task Save(TEntity entity)
        {
            await _session.SaveAsync(entity);
        }
    }
}