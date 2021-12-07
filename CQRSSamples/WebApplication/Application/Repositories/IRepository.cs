using System.Threading.Tasks;

namespace WebApplication.Application.Repositories
{
    public interface IRepository<TKey,TEntity>
    {
        Task Save(TEntity entity);
    }
}