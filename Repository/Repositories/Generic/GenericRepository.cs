using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
    public abstract class GenericRepository<TEntity> : IGenericRepositoryAsync<TEntity>
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

        public virtual Task<TEntity> GetByIdAsync(int id, bool toTrack = false, CancellationToken ct = default)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            if(!toTrack)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefaultAsync(e => e.Id == id, ct);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default)
        {
            var isValid = await ValidateEntity(entity, ct);
            if (!isValid)
            {
                return null;
            }
            var entityEntry = await _dbContext.Set<TEntity>().AddAsync(entity, ct).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(new object[] { entity.Id }, ct);
            var isValid = await ValidateEntity(entity, ct);
            if (existingEntity == null || !isValid)
            {
                return null;
            }
            var entityEntry = _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }
        public virtual async Task<IReadOnlyCollection<TEntity>> FindAsync(int skip = 0, int count = 1,
            bool toTrack = false,
            IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            CancellationToken ct = default)
        {

            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if(!toTrack)
            {
                query = query.AsNoTracking();
            }

            if (query.Count() < 1)
            {
                return await query.ToListAsync(ct); 
            }

            if (include != null)
            {
                query = include(query);
            }

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }
            
            query = query == null || orderBy == null ? query : orderBy(query);
            skip = skip < 0 || skip > int.MaxValue ? 0: skip;
            count = count <= 0 || count > int.MaxValue ? int.MaxValue : count;
            query = query.Skip(skip).Take(count);
            return await query.ToListAsync(ct);
        }
        public virtual async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct: ct).ConfigureAwait(false);
            if (entity != null)
            {
                return await DeleteAsync(entity);
            }

            return false;
        }
        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default) //unsafe
        {

            _dbContext.Set<TEntity>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync(ct);
        }
        public virtual async Task<bool> DeleteAsync(TEntity entity, CancellationToken ct = default)
        {     
            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
            return entityEntry != null;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(ct).ConfigureAwait(false);
        }

        public abstract Task<bool> ValidateEntity(TEntity entity, CancellationToken ct = default);
    }
}