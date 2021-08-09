using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.BLL.Models.FilterModels;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IPostProvider
    {
        Task<PostEntity> CreateAsync(PostEntity post, CancellationToken ct = default);
        Task<PostEntity> GetByIdAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteAsync(PostEntity entity, CancellationToken ct = default);
        Task<IReadOnlyCollection<PostResponse>> GetAsync(PostFiltersRequest model, CancellationToken ct = default);
        Task<PostResponse> UpdateAsync(PostEntity entity, CancellationToken ct = default);
        PostResponse ConvertToResponse(PostEntity entity);
    }
}
