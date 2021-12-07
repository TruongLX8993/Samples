using System.Threading.Tasks;

namespace WebApplication.Application.Repositories
{
    public interface IUnitOfWork
    {
        void Begin();
        Task Commit();
        Task Rollback();
        IRepository<TKey, TEntity> GetRepository<TKey, TEntity>();
    }
}