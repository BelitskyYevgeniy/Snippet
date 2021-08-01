using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    interface IPostProvider
    {
        Task<Post> MakeAsync(Post post, CancellationToken ct);
        Task<Post> GetByIdAsync(int id, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<Post>> GetAll(CancellationToken ct);
        Task<Post> UpdateAsync(Post model, CancellationToken ct);




    }
}
