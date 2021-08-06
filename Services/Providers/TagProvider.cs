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

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
             return await _tagRepository.DeleteAsync(id, ct);
        }

        public async Task<IReadOnlyCollection<Tag>> CreateAsync(IReadOnlyCollection<Tag> tags, CancellationToken ct) 
        {
            var entities = _mapper.Map<IReadOnlyCollection<Tag>, IReadOnlyCollection<TagEntity>>(tags);
            
            foreach (var entity in entities)
            {
                var tag = (await _tagRepository.FindAsync(filter: new Expression<Func<TagEntity, bool>>[] { (e) => e.Name == entity.Name }, 
                    includeProperties: new string[] { "Posts" },ct: ct).ConfigureAwait(false)).FirstOrDefault();
                if (tag == null)
                {
                    await _tagRepository.CreateAsync(entity, ct);
                }
            }
            return _mapper.Map<IReadOnlyCollection<Tag>>(entities);
        }

     /*   public async Task<Tag> UpdateAsync(Tag model, CancellationToken ct)
        {
            var entity = _mapper.Map<TagEntity>(model);

            entity = await _tagRepository.UpdateAsync(entity, ct);


            return _mapper.Map<Tag>(entity);
        }*/
    }
}
