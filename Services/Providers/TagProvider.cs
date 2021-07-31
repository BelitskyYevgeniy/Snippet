using AutoMapper;
using Services.Models;
using Snippet.BLL.Interfaces.Providers;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.BLL.Providers
{
    public class TagProvider : ITagProvider
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<TagEntity> _genericRepository;
        public TagProvider(IMapper mapper, IGenericRepositoryAsync<TagEntity> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _genericRepository.DeleteAsync(id, ct);// i maybe should use tag name
        }

        public async Task<IReadOnlyCollection<Tag>> GetAllByPostIdAsync(int postId, CancellationToken ct)
        {
            var entity = await _genericRepository.GetAllAsync(ct);//change this method
            return _mapper.Map<IReadOnlyCollection<TagEntity>,IReadOnlyCollection<Tag>>(entity);
        }

        public async Task<Tag> MakeAsync(Tag tag, CancellationToken ct) // i should use postId but interface does not have method with this parametres
        {
            var entity = _mapper.Map<Tag,TagEntity>(tag);
            entity = await _genericRepository.CreateAsync(entity, ct);

            return _mapper.Map<Tag>(entity);
        }

        public async Task<Tag> UpdateAsync(Tag model, CancellationToken ct)
        {
            var entity = _mapper.Map<TagEntity>(model);

            entity = await _genericRepository.CreateAsync(entity, ct);


            return _mapper.Map<Tag>(entity);
        }
    }
}
