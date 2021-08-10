using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models.ResponseModels;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class LanguageProvider : ILanguageProvider
    {

        private readonly IMapper _mapper;
        private readonly ILanguageRepositoryAsync _languageRepository;
        public LanguageProvider(IMapper mapper, ILanguageRepositoryAsync languageRepository,IPostProvider postProvider,IPostRepositoryAsync postRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

       /* public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            return await _languageRepository.DeleteAsync(id, ct);
        }*/

/*        public async Task<LanguageResponse> CreateAsync(LanguageRequest language, CancellationToken ct = default)
        {
            var entity = _mapper.Map<LanguageRequest, LanguageEntity>(language);
            entity = await _languageRepository.CreateAsync(entity, ct);

            return _mapper.Map<LanguageResponse>(entity);
        }*/

        public async Task<IReadOnlyCollection<LanguageResponse>> GetTopAsync(int count = 1, CancellationToken ct = default)
        {
            var result = await _languageRepository.GetTopAsync(count, ct);
            return _mapper.Map<IReadOnlyCollection<LanguageResponse>>(result);
        }

        public async Task<LanguageResponse> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _languageRepository.GetByIdAsync(id, ct : ct);
            return _mapper.Map<LanguageResponse>(entity);
        }
    }
}
