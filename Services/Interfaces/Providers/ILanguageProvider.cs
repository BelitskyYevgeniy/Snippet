using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<Language> MakeAsync(Language language, CancellationToken ct);
        Task<bool> DeleteAsync(Language language, CancellationToken ct);
        Task<Language> UpdateAsync(Language tag, CancellationToken ct);
    }
}
