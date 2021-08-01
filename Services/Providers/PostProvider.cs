using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class PostProvider : IPostProvider
    {
        private readonly IMapper _mapper;
        private readonly IPostRepositoryAsync _tagRepository;
        public PostProvider(IMapper mapper , IPostRepositoryAsync tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _tagRepository.DeleteAsync(id, ct);
        }


        public async Task<Post> GetByIdAsync(int id, CancellationToken ct)
        {
            var entity = await _tagRepository.GetByIdAsync(id, ct); 
            
            return _mapper.Map<Post>(entity); 
        }

        public async Task<IReadOnlyCollection<Post>> GetAll(CancellationToken ct)
        {
            var entities = await _tagRepository.GetAllAsync(ct);

            return _mapper.Map<IReadOnlyCollection<Post>>(entities);
        }

        public async Task<Post> MakeAsync(Post post, CancellationToken ct)
        {
            var entity = _mapper.Map<Post, PostEntity>(post);
            entity = await _tagRepository.CreateAsync(entity, ct);

           return _mapper.Map<Post>(entity);
        }

        public async Task<Post> UpdateAsync(Post model, CancellationToken ct)
        {
            var entity = _mapper.Map<PostEntity>(model);

            entity =await _tagRepository.UpdateAsync(entity,ct);
            

            return _mapper.Map<Post>(entity);
        }
    }
}