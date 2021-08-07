using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ICommentProvider
    {
        Task<CommentResponse> CreateAsync(CommentRequest comment, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<CommentResponse>> GetAllByPostIdAsync(int postId, int skip = 0, int count = 1, CancellationToken ct = default);
        Task<CommentResponse> UpdateAsync(CommentRequest model,int commentId, CancellationToken ct = default);
    }
}
