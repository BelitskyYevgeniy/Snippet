using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface IPostService
    {
        /*Task<PostResponse> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<PostResponse>> GetAll(CancellationToken ct);*/
        Task<Post> CreateAsync(Post model, CancellationToken ct = default);
    }
}
