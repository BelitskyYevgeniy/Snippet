using Microsoft.EntityFrameworkCore;
using Snippet.Data.Context;
using Snippet.Data.Entities.Base;
using Snippet.Data.Interfaces.Filters;
using Snippet.Data.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data
{ 
    public class GenericRepository<TEntity> : IGenericRepositoryAsync<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly RepositoryContext _dbContext;

        public Task<int> GetCount(CancellationToken ct = default)
        {
            return _dbContext.Set<TEntity>().CountAsync(ct);
        }

        public GenericRepository(RepositoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TEntity> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, ct);
        }
        public async Task<IReadOnlyCollection<TEntity>> GetAsync(int start, int count, IEnumerable<IFilter<TEntity>> filters, CancellationToken ct = default)
        {
            if(start < 0 || count < 0)
            {
                throw new ArgumentException();
            }

            var all = _dbContext.Set<TEntity>().AsNoTracking();

            if (!(filters == null || filters.Count() == 0))
            {
                foreach (var filter in filters)
                {
                    all = all.Where(e => filter.Predicate(e));
                }
            }

            return await all.Skip(start)
                        .Take(count)
                        .ToListAsync(ct)
                        .ConfigureAwait(false);
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
        public async Task<IReadOnlyCollection<TEntity>> FindAsync(Func<TEntity, bool> predicate, CancellationToken ct = default)
        {
            var list = await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync(ct).ConfigureAwait(false);
            var processedlist = list.Where(predicate).ToList();
            return new ReadOnlyCollection<TEntity>(processedlist);
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
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

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken ct)
        {
            int count = await GetCount(ct).ConfigureAwait(false);
            return await GetAsync(0, count, null, ct).ConfigureAwait(false);
        }
    }
}