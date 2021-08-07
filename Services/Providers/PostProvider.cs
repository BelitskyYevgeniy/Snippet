﻿using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.RequestModels;
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
        public PostProvider(IMapper mapper , IPostRepositoryAsync tagRepository)
        {
            _mapper = mapper;
            _postRepository = tagRepository;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            return await _postRepository.DeleteAsync(id, ct);
        }


        public async Task<Post> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _postRepository.GetByIdAsync(id, ct); 
            
            return _mapper.Map<Post>(entity); 
        }

        public async Task<IReadOnlyCollection<Post>> GetAsync(PostFiltersRequest model, CancellationToken ct = default)
        {
            var entityFilterModel = _mapper.Map<PostEntityFilterModel>(model);
            var entities = await _postRepository.FindAsync(entityFilterModel, ct);

            return _mapper.Map<List<Post>>(entities.ToList());
        }

        public async Task<PostRequest> CreateAsync(PostRequest post, CancellationToken ct = default)
        {
            var entity = _mapper.Map<PostRequest, PostEntity>(post);
            entity = await _postRepository.CreateAsync(entity, ct);

           return post;
        }

        public async Task<PostRequest> UpdateAsync(PostRequest model,int postId, CancellationToken ct = default)
        {
            var newEntity = _mapper.Map<PostRequest,PostEntity>(model);

            newEntity.Id = postId;
            

            newEntity =await _postRepository.UpdateAsync(newEntity,ct);

            return model;
        }
    }
}