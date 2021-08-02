using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.BLL.Interfaces.Providers
{
    public interface ITagProvider
    {
        Task<IReadOnlyCollection<Tag>> MakeAsync(IReadOnlyCollection<Tag> tags, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<Tag> UpdateAsync(Tag tag, CancellationToken ct);
    }
}
