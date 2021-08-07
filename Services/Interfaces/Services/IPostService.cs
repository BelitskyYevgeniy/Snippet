using Services.Models;
using Services.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface IPostService
    {
        /*Task<PostResponse> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<PostResponse>> GetAll(CancellationToken ct);*/
        Task<PostRequest> CreateAsync(PostRequest model, CancellationToken ct = default);
    }
}
