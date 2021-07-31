using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.BLL.Services
{
    public class PostProvider : IPostProvider
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<PostEntity> _genericRepository;
        public PostProvider(IMapper mapper ,IGenericRepositoryAsync<PostEntity> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _genericRepository.DeleteAsync(id, ct);
        }


        public async Task<Post> GetByIdAsync(int id, CancellationToken ct)
        {
            var entity = await _genericRepository.GetByIdAsync(id, ct); 
            
            return _mapper.Map<Post>(entity); 
        }

        public async Task<IReadOnlyCollection<Post>> GetAll(CancellationToken ct)
        {
            var entities = await _genericRepository.GetAllAsync(ct);

            return _mapper.Map<IReadOnlyCollection<Post>>(entities);
        }

        public async Task<Post> MakeAsync(Post post, CancellationToken ct)
        {
            var entity = _mapper.Map<Post, PostEntity>(post);
            entity = await _genericRepository.CreateAsync(entity, ct);

           return _mapper.Map<Post>(entity);
        }

        public async Task<Post> UpdateAsync(Post model, CancellationToken ct)
        {
            var entity = _mapper.Map<PostEntity>(model);

            entity =await _genericRepository.UpdateAsync(entity,ct);
            

            return _mapper.Map<Post>(entity);
        }
    }
}