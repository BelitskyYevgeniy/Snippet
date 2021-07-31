using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class LanguageProvider : ILanguageProvider
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<LanguageEntity> _genericRepository;
        public LanguageProvider(IMapper mapper, IGenericRepositoryAsync<LanguageEntity> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<bool> DeleteAsync(Language language, CancellationToken ct)
        {
            return await _genericRepository.DeleteAsync(language.Id, ct);
        }

        public async Task<Language> MakeAsync(Language language, CancellationToken ct)
        {
            var entity = _mapper.Map<Language, LanguageEntity>(language);
            entity = await _genericRepository.CreateAsync(entity, ct);

            return _mapper.Map<Language>(entity);
        }

        public async Task<Language> UpdateAsync(Language language, CancellationToken ct)
        {
            var entity = _mapper.Map<LanguageEntity>(language);

            entity = await _genericRepository.UpdateAsync(entity, ct);


            return _mapper.Map<Language>(entity);
        }
    }
}
