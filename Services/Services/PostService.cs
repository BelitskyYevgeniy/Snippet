using AutoMapper;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models;
using Services.Responses;
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
        private readonly ILikeProvider _likeProvider;

        public PostService(IMapper mapper,IPostProvider postProvider,ILikeProvider likeProvider)
        {
            _mapper = mapper;
            _postProvider = postProvider;
            _likeProvider = likeProvider;
        }

        public async Task<IReadOnlyCollection<PostResponse>> GetAll(CancellationToken ct)
        {
            var posts = await _postProvider.GetAll(ct);
            var responses = _mapper.Map<IReadOnlyCollection<Post>, IReadOnlyCollection<PostResponse>>(posts);
            for(int i = 0; i < posts.Count; i++)
            {
                var response = responses.ElementAt(i);
                var post = posts.ElementAt(i);
                response.LanguageName = post.Language.Name;
                response.OwnerId = post.Owner.Id;
                response.LikeCount = await _likeProvider.GetAllByPostAsync(posts.ElementAt(i).Id, ct);
            }

            return responses;
        }

        public async Task<PostResponse> GetByIdAsync(int id, CancellationToken ct)
        {
            var post = await _postProvider.GetByIdAsync(id, ct);
            var response = _mapper.Map<Post, PostResponse>(post);
            response.OwnerId = post.Owner.Id;
            response.LanguageName = post.Language.Name;
            response.LikeCount = await _likeProvider.GetAllByPostAsync(id, ct); 
            return response;
        }
    }
}
