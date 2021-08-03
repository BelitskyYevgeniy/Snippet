using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Data.Entities.Base;
using Snippet.Data.Interfaces.Filters;

namespace Snippet.Data.Interfaces.Generic
{
    public interface IGenericRepositoryAsync<TEntity>
        where TEntity : BaseEntity
    {
        Task<int> GetCount(CancellationToken ct);
        Task<IReadOnlyCollection<TEntity>> GetAsync(int start, int count, IEnumerable<IFilter<TEntity>> filters, CancellationToken ct);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken ct);
        Task<TEntity> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<TEntity>> FindAsync(Func<TEntity, bool> predicate, CancellationToken ct);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);
    }
}