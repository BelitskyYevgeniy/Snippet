using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<Language> MakeAsync(Language language, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<Language> UpdateAsync(Language tag, CancellationToken ct);
    }
}
