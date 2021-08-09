using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ITagRepositoryAsync: IGenericRepositoryAsync<TagEntity>
    {
        public Task UpdateTagsAsync(IEnumerable<PostTagEntity> currentItems, IEnumerable<PostTagEntity> newItems, CancellationToken ct = default);
    }
}
