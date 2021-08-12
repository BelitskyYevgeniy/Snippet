using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.BLL.Interfaces.Providers;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostProvider _postProvider;
        private readonly ITagProvider _tagProvider;
        private readonly ICommentProvider _commentProvider;
        private readonly ILikeProvider _likeProvider;
        private readonly ILanguageProvider _languageProvider;
        private readonly IAuthenticationService _authenticationService;

        private async Task<PostResponse> UpdateAsync(PostEntity entity, IReadOnlyCollection<TagRequest> tags, CancellationToken ct = default)
        {
            var setTags = new HashSet<TagRequest>(tags);
            var newTags = await _tagProvider.CreateAsync(setTags, ct);
            var currentPostTags = entity.PostTags.Select(pt => new PostTagEntity
            {
                PostId = pt.PostId,
                TagId = pt.TagId,
                Tag = null,
                Post = null
            }).ToList();
            var response = await _postProvider.UpdateAsync(entity, ct);
            var newPostTags = newTags.Select(tag => new PostTagEntity
            {
                TagId = tag.Id,
                PostId = entity.Id,
                Tag = null,
                Post = null
            }).ToList();
            await _tagProvider.UpdateTagsAsync(currentPostTags, newPostTags, ct);
            
            response.Tags = _mapper.Map<List<TagResponse>>(newTags);
            return response;
        }


        public PostService(IMapper mapper, IPostProvider postProvider, ITagProvider tagProvider, 
            ICommentProvider commentProvider, ILikeProvider likeProvider, 
            ILanguageProvider languageProvider, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _postProvider = postProvider;
            _tagProvider = tagProvider;
            _commentProvider = commentProvider;
            _likeProvider = likeProvider;
            _languageProvider = languageProvider;
            _authenticationService = authenticationService;
        }

        

        
        [Authorize]
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var post = await _postProvider.GetByIdAsync(id, false, ct);
            var user = await _authenticationService.GetUserAsync(ct);
            var isAllowedToDelete = user.Id == post.UserId;
            if (post == null || !isAllowedToDelete)
            {
                return false;
            }
            await _commentProvider.DeleteAllByPostIdAsync(id, ct);
            await _likeProvider.DeleteLikesOfPostAsync(id, ct);
            await _tagProvider.UpdateTagsAsync(post.PostTags, null, ct);
            return await _postProvider.DeleteAsync(post, ct);
        }


        public async Task<PostResponse> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var post = await _postProvider.GetByIdAsync(id, ct: ct);
            return _postProvider.ConvertToResponse(post);
        }


        [Authorize]
        public async Task<PostResponse> CreateAsync(PostRequest model, CancellationToken ct = default)
        {
            if(model == null)
            {
                return null;
            }
            var entity = _mapper.Map<PostEntity>(model);
            entity.UserId = (await _authenticationService.GetUserAsync(ct)).Id;
            entity = await _postProvider.CreateAsync(entity, ct);
            if(entity == null)
            {
                return null;
            }
            entity.PostTags = new List<PostTagEntity>();
            if(model.Tags == null)
            {
                model.Tags = new List<TagRequest>();
            }
            var response = await UpdateAsync(entity, model.Tags, ct);
            response.Language = await _languageProvider.GetByIdAsync(entity.LanguageId, ct);
            return response;
        }

        [Authorize]
        public async Task<PostResponse> UpdateAsync(int postId, PostRequest model, CancellationToken ct = default)
        {
            var existingPost = await _postProvider.GetByIdAsync(postId, ct: ct);
            if(existingPost == null || model == null)
            {
                return null;
            }
            var user = await _authenticationService.GetUserAsync(ct);
            var isAllowedToUpdate = user.Id == existingPost.UserId;
            if (!isAllowedToUpdate)
            {
                return null;
            }
            var entityModel = _mapper.Map<PostEntity>(model);
            if (model.Tags == null)
            {
                model.Tags = new List<TagRequest>();
            }
            entityModel.Id = postId;
            entityModel.CreationDateTime = existingPost.CreationDateTime;
            entityModel.PostTags = existingPost.PostTags;
            return await UpdateAsync(entityModel, model.Tags, ct);
        }
    }
}
