using Snippet.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.BLL.Interfaces.Providers
{
    public interface ICommentProvider
    {
        Task<Comment> MakeAsync(Comment comment, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<Comment>> GetAllByPostIdAsync(int postId, CancellationToken ct);
        Task<Comment> UpdateAsync(Comment model, CancellationToken ct);
    }
}
