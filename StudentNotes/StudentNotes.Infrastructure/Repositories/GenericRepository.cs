using StudentNotes.Application.IRepositories;
using StudentNotes.Application.Paging;
using StudentNotes.Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StudentNotes.Infrastructure.ApplicationContext;

namespace StudentNotes.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private DbSet<TEntity> _table;
        private EFContext _db;

        public async Task AddAsync(TEntity item)
        {
            await _table.AddAsync(item);
        }
        
        public void Attach(params object[] obj)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(TEntity item)
        {
            await _table.Remove(item);        }
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await this._tabl
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetOneAsync(int id)
        {
            return await _table.Find(id);
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
    
        public async Task SaveAsync()
        {
            await _db.SaveChanges();
        }
    
        public async Task UpdateAsync(TEntity item)
        {
            await _db.Entry(item).State = EntityState.Modified;
        }
    }
}
