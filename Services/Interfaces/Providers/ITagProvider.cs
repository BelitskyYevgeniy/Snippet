using Services.Models;
using Services.Models.RequestModels;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.BLL.Interfaces.Providers
{
    public interface ITagProvider
    {
        public Task<IReadOnlyCollection<TagEntity>> CreateAsync(IReadOnlyCollection<TagRequest> tags, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task UpdateTagsAsync(IEnumerable<PostTagEntity> currentItems, IEnumerable<PostTagEntity> newItems, CancellationToken ct = default);
    }
}
