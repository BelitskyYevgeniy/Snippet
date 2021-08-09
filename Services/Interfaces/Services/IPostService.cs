using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface IPostService
    {
        Task<PostResponse> UpdateAsync(int postId, PostRequest model, CancellationToken ct = default);
        Task<PostResponse> CreateAsync(PostRequest model, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<PostResponse> GetByIdAsync(int id, CancellationToken ct = default);




    }
}
