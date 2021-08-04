using Services.Models;
using Snippet.BLL.Models.RequestModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
   public interface IPostProvider
    {
        Task<Post> CreateAsync(Post post, CancellationToken ct);
        Task<Post> GetByIdAsync(int id, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<Post>> GetAsync(PostFiltersRequestModel model, CancellationToken ct);
        Task<Post> UpdateAsync(Post model, CancellationToken ct);




    }
}
