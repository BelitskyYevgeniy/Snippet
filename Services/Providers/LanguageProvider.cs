using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.BLL.Models.FilterModels;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;
using Snippet.Data.Interfaces.Generic;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class LanguageProvider : ILanguageProvider
    {

        private readonly IMapper _mapper;
        private readonly ILanguageRepositoryAsync _languageRepository;
        private readonly IPostProvider _postProvider;
        private readonly IPostRepositoryAsync _postRepository;
        public LanguageProvider(IMapper mapper, ILanguageRepositoryAsync languageRepository,IPostProvider postProvider,IPostRepositoryAsync postRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _postProvider = postProvider;
            _postRepository = postRepository; 
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            return await _languageRepository.DeleteAsync(id, ct);
        }

        public async Task<LanguageResponse> CreateAsync(LanguageRequest language, CancellationToken ct = default)
        {
            var entity = _mapper.Map<LanguageRequest, LanguageEntity>(language);
            entity = await _languageRepository.CreateAsync(entity, ct);

            return _mapper.Map<LanguageResponse>(entity);
        }

        public async Task<IReadOnlyCollection<LanguageResponse>> GetRating(CancellationToken ct)
        {
            var posts = await _postProvider.GetAsync(new PostFiltersRequest { Skip = 0, Count = _postRepository.GetCount(ct).Result }, ct);
            var languages = posts.GroupBy(x => x.Language.Name).Select(x => new { Name = x.Key, Count = x.Count() }).OrderByDescending(x=>x.Count);
            List<LanguageResponse> languagesRating = new List<LanguageResponse>();
            foreach(var language in languages)
            {
                LanguageResponse languageResponse =new LanguageResponse {Name =  language.Name };
                languagesRating.Add(languageResponse);
                
            }

            return languagesRating;
        }

        //public async Task<Language> UpdateAsync(Language language, CancellationToken ct = default)
        //{
        //    var entity = _mapper.Map<LanguageEntity>(language);

        //    entity = await _languageRepository.UpdateAsync(entity, ct);


        //    return _mapper.Map<Language>(entity);
        //}

        public async Task<Language> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _languageRepository.GetByIdAsync(id, ct);
            return _mapper.Map<Language>(entity);
        }
    }
}
