using System;
using System.Threading.Tasks;
using NHibernate;
using WebApplication.Application.Repositories;

namespace WebApplication.Infrastructures.Data.NhibernateRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Begin()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            if (_transaction == null)
            {
                throw new Exception("Have not transaction");
            }

            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            if (_transaction == null)
            {
                throw new Exception("Have not transaction");
            }

            await _transaction.RollbackAsync();
        }

        public IRepository<TKey, TEntity> GetRepository<TKey, TEntity>()
        {
            return new NhibernateRepository<TKey, TEntity>(_session);
        }
    }
}