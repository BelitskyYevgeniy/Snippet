using Services.Models;
using Snippet.BLL.Models.FilterModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IPostProvider
    {
        Task<Post> CreateAsync(Post post, CancellationToken ct = default);
        Task<Post> GetByIdAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<Post>> GetAsync(PostFiltersRequest model, CancellationToken ct = default);
        Task<Post> UpdateAsync(Post model, CancellationToken ct = default);




    }
}
