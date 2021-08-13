using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface IPostRepositoryAsync : IGenericRepositoryAsync<PostEntity>
    { 
        Task<IReadOnlyCollection<PostEntity>> FindAsync(PostEntityFilterModel model, CancellationToken ct = default);

    }
}
