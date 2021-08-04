using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<Language> CreateAsync(Language language, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<Language> UpdateAsync(Language tag, CancellationToken ct = default);
        Task<Language> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
