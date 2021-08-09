using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.BLL.Models.FilterModels;
using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Interfaces.Repositories;
using System;
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

        

        public PostProvider(IMapper mapper , IPostRepositoryAsync tagRepository)
        {
            _mapper = mapper;
            _postRepository = tagRepository;

        }

        public PostResponse ConvertToResponse(PostEntity entity)
        {

            var response = _mapper.Map<PostResponse>(entity);
            if (entity.PostTags == null || entity.PostTags.Count == 0)
            {
                response.Tags = new List<TagResponse>();
            }
            else
            {
                response.Tags = _mapper.Map<List<TagResponse>>(
                    entity.PostTags.Select(e => e.Tag).ToList());
            }
            return response;
        }


        public async Task<bool> DeleteAsync(PostEntity entity, CancellationToken ct = default)
        {
            return await _postRepository.DeleteAsync(entity, ct);
        }
        public Task<PostEntity> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _postRepository.GetByIdAsync(id, ct); 
        }

        public async Task<IReadOnlyCollection<PostResponse>> GetAsync(PostFiltersRequest model, CancellationToken ct = default)
        {
            var entityFilterModel = _mapper.Map<PostEntityFilterModel>(model);
            var posts = await _postRepository.FindAsync(entityFilterModel, ct);
            var responses = new List<PostResponse>();
            foreach(var post in posts)
            {
                responses.Add(ConvertToResponse(post));
            }
            return responses;
        }

        public Task<PostEntity> CreateAsync(PostEntity post, CancellationToken ct = default)
        {
            post.CreationDateTime = System.DateTime.Now;
            post.LastUpdateDateTime = post.CreationDateTime;
            return _postRepository.CreateAsync(post, ct);
        }

        public async Task<PostResponse> UpdateAsync(PostEntity entity, CancellationToken ct = default)
        {
            entity.PostTags = null;
            entity.LastUpdateDateTime = DateTime.Now;
            var newEntity = await _postRepository.UpdateAsync(entity, ct);

            return _mapper.Map<PostEntity, PostResponse>(newEntity);
        }
    }
}