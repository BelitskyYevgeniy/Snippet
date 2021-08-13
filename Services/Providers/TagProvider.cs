using AutoMapper;
using Services.Models;
using Snippet.BLL.Interfaces.Providers;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;

namespace Services.Providers
{
    public class TagProvider : ITagProvider
    {
        private readonly IMapper _mapper;
        private readonly ITagRepositoryAsync _tagRepository;
      
        public TagProvider(IMapper mapper, ITagRepositoryAsync tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            
        }

        public async Task<IReadOnlyCollection<TagResponse>> GetTopAsync(int count = int.MaxValue, CancellationToken ct = default)
        {
            var result = await _tagRepository.GetTopAsync(count, ct);
            return _mapper.Map<IReadOnlyCollection<TagResponse>>(result);
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
             return await _tagRepository.DeleteAsync(id, ct);
        }

        public async Task<IReadOnlyCollection<TagEntity>> CreateAsync(IReadOnlyCollection<TagRequest> tags, CancellationToken ct = default) 
        {
            var entities = _mapper.Map<IReadOnlyCollection<TagEntity>>(tags);
            if (entities == null)
            {
                return null;
            }
            var result = new List<TagEntity>();
            foreach (var entity in entities)
            {
                var tag = (await _tagRepository.FindAsync(filter: new Expression<Func<TagEntity, bool>>[] { (e) => e.Name == entity.Name }, ct: ct)
                    .ConfigureAwait(false)).FirstOrDefault();
                if (tag == null)
                {
                    tag = await _tagRepository.CreateAsync(entity, ct);
                }
                result.Add(tag);
            }
            return result;
        }

        public Task UpdateTagsAsync(IEnumerable<PostTagEntity> currentItems, IEnumerable<PostTagEntity> newItems, CancellationToken ct = default)
        {
            return _tagRepository.UpdateTagsAsync(currentItems, newItems, ct);
        }
    }
}
