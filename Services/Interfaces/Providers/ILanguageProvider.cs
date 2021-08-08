using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<LanguageResponse> CreateAsync(LanguageRequest language, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
       // Task<Language> UpdateAsync(Language tag, CancellationToken ct = default);
        Task<Language> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
