using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        //Task<LanguageResponse> CreateAsync(LanguageRequest language, CancellationToken ct = default);
        //Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<LanguageResponse>> GetTopAsync(int count = int.MaxValue, CancellationToken ct = default);
        //Task<Language> UpdateAsync(Language tag, CancellationToken ct = default);
        Task<LanguageResponse> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
