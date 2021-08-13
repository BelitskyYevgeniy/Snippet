using Services.Models.ResponseModels;
using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IPostProvider
    {
        Task<PostEntity> CreateAsync(PostEntity post, CancellationToken ct = default);
        Task<PostEntity> GetByIdAsync(int id, bool toTracke = false, CancellationToken ct = default);
        Task<bool> DeleteAsync(PostEntity entity, CancellationToken ct = default);
        Task<IReadOnlyCollection<PostResponse>> GetAsync(PostEntityFilterModel model, CancellationToken ct = default);
        Task<PostResponse> UpdateAsync(PostEntity entity, CancellationToken ct = default);
        PostResponse ConvertToResponse(PostEntity entity);
        Task<int> GetCount(CancellationToken ct);
    }
}
