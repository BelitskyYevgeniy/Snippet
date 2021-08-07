﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Data.Entities.Base;

namespace Snippet.Data.Interfaces.Generic
{
    public interface IGenericRepositoryAsync<TEntity>
        where TEntity : BaseEntity
    {
        Task<int> GetCount(CancellationToken ct);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task<TEntity> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<TEntity>> FindAsync(int skip = 0, int count = 1,
            IEnumerable<Expression<Func<TEntity, bool>>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null,
            CancellationToken ct = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default);
        Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken ct = default);
        Task<int> DeleterRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default)
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default);
        
    }
}