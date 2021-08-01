using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Data.Entities.Base;

namespace Snippet.Data.Interfaces.Generic
{
    public interface IGenericRepositoryAsync<T>
        where T : BaseEntity
    {
        Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken ct);
        Task<T> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<T>> FindAsync(Func<T, bool> predicate, CancellationToken ct);
        Task<T> CreateAsync(T entity, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<T> UpdateAsync(T entity, CancellationToken ct);
    }
}