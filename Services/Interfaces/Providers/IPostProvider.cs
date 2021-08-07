using Services.Models;
using Services.Models.RequestModels;
using Snippet.BLL.Models.FilterModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IPostProvider
    {
        Task<PostRequest> CreateAsync(PostRequest post, CancellationToken ct = default);
        Task<Post> GetByIdAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<Post>> GetAsync(PostFiltersRequest model, CancellationToken ct = default);
        Task<PostRequest> UpdateAsync(PostRequest model,int postId, CancellationToken ct = default);




    }
}
