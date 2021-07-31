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
        private readonly IGenericRepositoryAsync<TagEntity> _tagRepository;
        private readonly IGenericRepositoryAsync<PostEntity> _postRepository;
        public TagProvider(IMapper mapper, IGenericRepositoryAsync<TagEntity> TagRepository, IGenericRepositoryAsync<PostEntity> PostRepository)
        {
            _mapper = mapper;
            _tagRepository = TagRepository;
            _postRepository = PostRepository;
        }

        public async Task<bool> DeleteAsync(Tag tag, CancellationToken ct)
        {
             return await _tagRepository.DeleteAsync(tag.Id, ct);
        }

        public async Task<IReadOnlyCollection<Tag>> GetAllByPostIdAsync(int postId, CancellationToken ct)
        {
            var post = await _postRepository.GetByIdAsync(postId, ct);
            IReadOnlyCollection<TagEntity> tags = post.Tags;
            return _mapper.Map<IReadOnlyCollection<TagEntity>,IReadOnlyCollection<Tag>>(tags);
        }

        public async Task<IReadOnlyCollection<Tag>> MakeAsync(IReadOnlyCollection<Tag>? tags, CancellationToken ct) 
        {
            var entities = _mapper.Map<IReadOnlyCollection<Tag>, IReadOnlyCollection<TagEntity>>(tags);
            
            foreach (var entity in entities)
            {
                 await _tagRepository.CreateAsync(entity, ct);
            }
            return _mapper.Map<IReadOnlyCollection<Tag>>(entities);
        }

        public async Task<Tag> UpdateAsync(Tag model, CancellationToken ct)
        {
            var entity = _mapper.Map<TagEntity>(model);

            entity = await _tagRepository.CreateAsync(entity, ct);


            return _mapper.Map<Tag>(entity);
        }
    }
}
