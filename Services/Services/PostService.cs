using AutoMapper;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models;
using Snippet.BLL.Interfaces.Providers;
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

        public PostService(IMapper mapper, IPostProvider postProvider, ITagProvider tagProvider)
        {
            _mapper = mapper;
            _postProvider = postProvider;
            _tagProvider = tagProvider;
        }
        
        public async Task<Post> CreateAsync(Post model, CancellationToken ct = default)
        {
            model.Tags = (await _tagProvider.CreateAsync(model.Tags, ct).ConfigureAwait(false)).ToList();

            return await _postProvider.CreateAsync(model, ct).ConfigureAwait(false);
        }
    }
}
