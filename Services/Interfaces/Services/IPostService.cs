using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface IPostService
    {
        /*Task<PostResponse> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<PostResponse>> GetAll(CancellationToken ct);*/
        Task<PostResponse> CreateAsync(PostRequest model, CancellationToken ct = default);
    }
}
