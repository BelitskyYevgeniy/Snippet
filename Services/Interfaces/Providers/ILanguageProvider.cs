using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<LanguageResponse> CreateAsync(LanguageRequest language, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<LanguageResponse>> GetRating(CancellationToken ct);
       // Task<Language> UpdateAsync(Language tag, CancellationToken ct = default);
        Task<Language> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
