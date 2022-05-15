using StudentNotes.Application.IRepositories;
using StudentNotes.Application.Paging;
using StudentNotes.Core.Entities;
using System.Linq.Expressions;

namespace StudentNotes.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        public Task AddAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Attach(params object[] obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetOneAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
