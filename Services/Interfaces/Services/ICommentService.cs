using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface ICommentService
    {
        Task<CommentResponse> GetByIdAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<CommentResponse> CreateAsync(CommentRequest comment, CancellationToken ct = default);
        Task<CommentResponse> UpdateAsync(int id, CommentRequest model, CancellationToken ct = default);
    }
}
