using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ILanguageRepositoryAsync: IGenericRepositoryAsync<LanguageEntity>
    {
        Task<IReadOnlyCollection<LanguageEntity>> GetTopAsync(int count = int.MaxValue, CancellationToken ct = default);
    }
}
