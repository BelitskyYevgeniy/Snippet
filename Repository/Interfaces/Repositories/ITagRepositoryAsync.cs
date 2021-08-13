using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ITagRepositoryAsync: IGenericRepositoryAsync<TagEntity>
    {
        Task<IReadOnlyCollection<TagEntity>> GetTopAsync(int count = int.MaxValue, CancellationToken ct = default);
        Task UpdateTagsAsync(IEnumerable<PostTagEntity> currentItems, IEnumerable<PostTagEntity> newItems, CancellationToken ct = default);
    }
}
