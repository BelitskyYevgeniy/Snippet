using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.BLL.Models.FilterModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IPostProvider
    {
        Task<PostResponse> CreateAsync(PostRequest post, CancellationToken ct = default);
        Task<PostResponse> GetByIdAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<PostResponse>> GetAsync(PostFiltersRequest model, CancellationToken ct = default);
        Task<PostResponse> UpdateAsync(PostRequest model,int postId, CancellationToken ct = default);




    }
}
