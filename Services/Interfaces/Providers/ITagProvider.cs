using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.BLL.Interfaces.Providers
{
    public interface ITagProvider
    {
        Task<IReadOnlyCollection<TagResponse>> GetTopAsync(int count = int.MaxValue, CancellationToken ct = default);
        public Task<IReadOnlyCollection<TagEntity>> CreateAsync(IReadOnlyCollection<TagRequest> tags, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task UpdateTagsAsync(IEnumerable<PostTagEntity> currentItems, IEnumerable<PostTagEntity> newItems, CancellationToken ct = default);
    }
}
