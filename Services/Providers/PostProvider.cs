using AutoMapper;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.ResponseModels;
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
        private readonly IPaginationService _paginationService;
        

        public PostProvider(IMapper mapper, IPostRepositoryAsync tagRepository, IPaginationService paginationService)
        {
            _mapper = mapper;
            _postRepository = tagRepository;
            _paginationService = paginationService;
        }

        public PostResponse ConvertToResponse(PostEntity entity)
        {
            if(entity == null)
            {
                return null;
            }
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


        public async Task<bool> DeleteAsync(PostEntity entity, CancellationToken ct = default)//unsafe
        {
            return await _postRepository.DeleteAsync(entity, ct);
        }
        public Task<PostEntity> GetByIdAsync(int id, bool toTracke = false, CancellationToken ct = default)
        {
            return _postRepository.GetByIdAsync(id, toTracke, ct); 
        }

        public async Task<IReadOnlyCollection<PostResponse>> GetAsync(PostEntityFilterModel model, CancellationToken ct = default)
        {
            if(model == null)
            {
                return null;
            }
            model.Count = _paginationService.ValidateCount(model.Count);
            model.Skip = _paginationService.ValidateSkip(model.Skip);
            var posts = await _postRepository.FindAsync(model, ct);
            var responses = new List<PostResponse>();
            foreach(var post in posts)
            {
                responses.Add(ConvertToResponse(post));
            }
            return responses;
        }

        public Task<PostEntity> CreateAsync(PostEntity post, CancellationToken ct = default)
        {
            if(post == null)
            {
                return null;
            }
            post.CreationDateTime = DateTime.Now;
            post.LastUpdateDateTime = post.CreationDateTime;
            return _postRepository.CreateAsync(post, ct);
        }

        public async Task<PostResponse> UpdateAsync(PostEntity entity, CancellationToken ct = default)
        {
            if (entity == null)
            {
                return null;
            }
            entity.PostTags = null;
            entity.LastUpdateDateTime = DateTime.Now;
            var newEntity = await _postRepository.UpdateAsync(entity, ct);

            return _mapper.Map<PostEntity, PostResponse>(newEntity);
        }

        public async Task<int> GetCount(CancellationToken ct = default)
        {
            var count =await _postRepository.GetCount(ct);
            return count;
        }
    }
}