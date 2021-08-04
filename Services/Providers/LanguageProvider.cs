using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;
using Snippet.Data.Interfaces.Generic;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class LanguageProvider : ILanguageProvider
    {

        private readonly IMapper _mapper;
        private readonly ILanguageRepositoryAsync _languageRepository;
        public LanguageProvider(IMapper mapper, ILanguageRepositoryAsync languageRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _languageRepository.DeleteAsync(id, ct);
        }

        public async Task<Language> MakeAsync(Language language, CancellationToken ct)
        {
            var entity = _mapper.Map<Language, LanguageEntity>(language);
            entity = await _languageRepository.CreateAsync(entity, ct);

            return _mapper.Map<Language>(entity);
        }

        public async Task<Language> UpdateAsync(Language language, CancellationToken ct)
        {
            var entity = _mapper.Map<LanguageEntity>(language);

            entity = await _languageRepository.UpdateAsync(entity, ct);


            return _mapper.Map<Language>(entity);
        }
    }
}
