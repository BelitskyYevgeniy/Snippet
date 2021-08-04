using Microsoft.EntityFrameworkCore;
using Snippet.Data.Context;
using Snippet.Data.Entities.Base;
using Snippet.Data.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data
{
    public class GenericRepository<TEntity> : IGenericRepositoryAsync<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly RepositoryContext _dbContext;
        protected virtual bool ValidatePagination(int start, int count)
        {
            return start >= 0 && count > 0;
        }

        public GenericRepository(RepositoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual Task<int> GetCount(CancellationToken ct = default)
        {
            return _dbContext.Set<TEntity>().CountAsync(ct);
        }

        public virtual Task<TEntity> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, ct);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Set<TEntity>().AddAsync(entity, ct).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }
        public virtual async Task<IReadOnlyCollection<TEntity>> FindAsync(int skip = 0, int count = 1,
            Func<TEntity, bool> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null,
            CancellationToken ct = default)
        {

            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(e => filter(e));
            }


            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    try
                    {
                        query = query.Include(includeProperty);
                    }
                    catch { }
                }
            }
            query = query == null || orderBy == null ? query : orderBy(query);
            query = ValidatePagination(skip, count) ? query.Skip(skip).Take(count) : query;
            return await query.AsNoTracking().ToListAsync(ct);
        }
        public virtual async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
                return entityEntry != null;
            }

            return false;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken ct)
        {
            
            return await _dbContext.Set<TEntity>().ToListAsync(ct).ConfigureAwait(false);
        }
    }
}