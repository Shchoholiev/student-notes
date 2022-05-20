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
        public GenericRepository(EFContext dbContext)
        {
            this._db = dbContext;
            this._table = dbContext.Set<TEntity>();
        }

        private DbSet<TEntity> _table;

        private EFContext _db;

        public async Task AddAsync(TEntity item)
        {
            await this._table.AddAsync(item);
            this.SaveAsync();
        }

        public void Attach(params object[] obj)
        {
            this._db.AttachRange(obj);
            this.SaveAsync();
        }

        public async Task DeleteAsync(TEntity item)
        {
            this._table.Remove(item);
            this.SaveAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if(this._table.FirstOrDefaultAsync<TEntity>(predicate) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this._db.Set<TEntity>();
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query.AsNoTracking().Where(predicate);
        }

        public async Task<TEntity> GetOneAsync(int id)
        {
            return await this._table.FirstOrDefaultAsync<TEntity>(entity => entity.Id == id);
        }

        public async Task<TEntity> GetOneAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this._table.AsNoTracking().Where(entity => entity.Id == id);
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return await query.FirstOrDefaultAsync<TEntity>(entity => entity.Id == id);
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters)
        {
            var items = this._table.Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize).Take(pageParameters.PageSize);
            var pagedList = new PagedList<TEntity>(items, pageParameters, items.Count());
            return pagedList;
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var items = this._table.AsNoTracking();
            foreach (var property in includeProperties)
            {
                items = items.Include(property);
            }
            var resultItems = items.Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize).Take(pageParameters.PageSize);
            var pagedList = new PagedList<TEntity>(resultItems, pageParameters, resultItems.Count());
            return pagedList;
        }

        public async Task<PagedList<TEntity>> GetPageAsync(PageParameters pageParameters, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var items = this._table.AsNoTracking().Where<TEntity>(predicate);
            foreach (var property in includeProperties)
            {
                items = items.Include(property);
            }
            var resultItems = items.Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize).Take(pageParameters.PageSize);
            var pagedList = new PagedList<TEntity>(resultItems, pageParameters, resultItems.Count());
            return pagedList;
        }

        public async Task SaveAsync()
        {
            await this._db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            this._db.Entry(item).State = EntityState.Modified;
            this.SaveAsync();
        }
    }
}
