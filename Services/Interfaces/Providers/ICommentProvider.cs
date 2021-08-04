using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ICommentProvider
    {
        Task<Comment> CreateAsync(Comment comment, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<Comment>> GetAllByPostIdAsync(int postId, int skip = 0, int count = 1, CancellationToken ct = default);
        Task<Comment> UpdateAsync(Comment model, CancellationToken ct = default);
    }
}
