using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ICommentProvider
    {
        Task<CommentResponse> CreateAsync(CommentRequest comment, CancellationToken ct = default);
        Task<bool> DeleteAsync(CommentEntity entity, CancellationToken ct = default);
        Task<IReadOnlyCollection<CommentResponse>> GetAllByPostIdAsync(int postId, int skip = 0, int count = int.MaxValue, CancellationToken ct = default);
        Task<CommentResponse> UpdateAsync(CommentEntity entity, CancellationToken ct = default);
        Task DeleteAllByPostIdAsync(int postId, CancellationToken ct = default);
        Task<CommentEntity> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
