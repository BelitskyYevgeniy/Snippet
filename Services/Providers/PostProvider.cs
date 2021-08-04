using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class PostProvider : IPostProvider
    {
        private readonly IMapper _mapper;
        private readonly IPostRepositoryAsync _postRepository;
        public PostProvider(IMapper mapper , IPostRepositoryAsync tagRepository)
        {
            _mapper = mapper;
            _postRepository = tagRepository;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _postRepository.DeleteAsync(id, ct);
        }


        public async Task<Post> GetByIdAsync(int id, CancellationToken ct)
        {
            var entity = await _postRepository.GetByIdAsync(id, ct); 
            
            return _mapper.Map<Post>(entity); 
        }

        public async Task<IReadOnlyCollection<Post>> GetAll(CancellationToken ct)
        {
            var entities = await _postRepository.GetAllAsync(ct);

            return _mapper.Map<IReadOnlyCollection<Post>>(entities);
        }

        public async Task<Post> MakeAsync(Post post, CancellationToken ct)
        {
            var entity = _mapper.Map<Post, PostEntity>(post);
            entity = await _postRepository.CreateAsync(entity, ct);

           return _mapper.Map<Post>(entity);
        }

        public async Task<Post> UpdateAsync(Post model, CancellationToken ct)
        {
            var entity = _mapper.Map<PostEntity>(model);

            entity =await _postRepository.UpdateAsync(entity,ct);
            

            return _mapper.Map<Post>(entity);
        }
    }
}