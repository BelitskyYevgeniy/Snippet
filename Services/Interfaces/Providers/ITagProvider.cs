using Snippet.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.BLL.Interfaces.Providers
{
    public interface ITagProvider
    {
        Task<Tag> MakeAsync(Tag tag, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<Tag>> GetAllByPostIdAsync(int postId, CancellationToken ct);
        Task<Tag> UpdateAsync(Tag model, CancellationToken ct);
    }
}
