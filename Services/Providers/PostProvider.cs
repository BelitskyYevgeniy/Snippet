using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.BLL.Models.FilterModels;
using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class PostProvider : IPostProvider
    {
        private readonly IMapper _mapper;
        private readonly IPostRepositoryAsync _postRepository;
        private readonly ICommentRepositoryAsync _commentRepository;
        private readonly ICommentProvider _commentProvider;
        public PostProvider(IMapper mapper , IPostRepositoryAsync tagRepository,ICommentProvider commentProvider,ICommentRepositoryAsync commentRepository)
        {
            _mapper = mapper;
            _postRepository = tagRepository;
            _commentProvider = commentProvider;
            _commentRepository = commentRepository;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var comments =await _commentProvider.GetAllByPostIdAsync(id,0,await _commentRepository.GetCount(ct), ct);
            foreach(var comment in comments)
            {
                await _commentProvider.DeleteAsync(comment.Id, ct);
            }

            return await _postRepository.DeleteAsync(id, ct);
        }


        public async Task<PostResponse> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _postRepository.GetByIdAsync(id, ct); 
            
            return _mapper.Map<PostResponse>(entity); 
        }

        public async Task<IReadOnlyCollection<PostResponse>> GetAsync(PostFiltersRequest model, CancellationToken ct = default)
        {
            var entityFilterModel = _mapper.Map<PostEntityFilterModel>(model);
            var entities = await _postRepository.FindAsync(entityFilterModel, ct);

            return _mapper.Map<List<PostResponse>>(entities.ToList());
        }

        public async Task<PostResponse> CreateAsync(PostRequest post, CancellationToken ct = default)
        {

            var entity = _mapper.Map<PostRequest, PostEntity>(post);
            entity.CreationDateTime = System.DateTime.Now; 
            entity = await _postRepository.CreateAsync(entity, ct);

           return _mapper.Map<PostEntity,PostResponse>(entity);
        }

        public async Task<PostResponse> UpdateAsync(PostRequest model,int postId, CancellationToken ct = default)
        {
            var newEntity = _mapper.Map<PostRequest,PostEntity>(model);

            newEntity.Id = postId;
            

            newEntity =await _postRepository.UpdateAsync(newEntity,ct);

            return _mapper.Map<PostEntity, PostResponse>(newEntity);
        }
    }
}