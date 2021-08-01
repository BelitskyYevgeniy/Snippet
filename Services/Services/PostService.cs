using AutoMapper;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostProvider _postProvider;

        public PostService(IMapper mapper,IPostProvider postProvider)
        {
            _mapper = mapper;
            _postProvider = postProvider;
        }

        public async Task<IReadOnlyCollection<PostResponse>> GetAll(CancellationToken ct)
        {
            var posts = await _postProvider.GetAll(ct);
            var responses = _mapper.Map<IReadOnlyCollection<Post>, IReadOnlyCollection<PostResponse>>(posts);
            for(int i = 0; i < posts.Count; i++)
            {
                responses.ElementAt(i).LanguageName = posts.ElementAt(i).Language.Name;
                responses.ElementAt(i).OwnerName = posts.ElementAt(i).Owner.Name;
            }

            return responses;
        }

        public async Task<PostResponse> GetByIdAsync(int id, CancellationToken ct)
        {
            var post = await _postProvider.GetByIdAsync(id, ct);
            var response = _mapper.Map<Post, PostResponse>(post);
            response.OwnerName = post.Owner.Name;
            response.LanguageName = post.Language.Name;

            return response;
        }
    }
}
