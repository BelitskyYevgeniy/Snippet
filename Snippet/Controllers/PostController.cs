using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.Data.Filters.FilterModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PostController:ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IPostProvider _postProvider;

        public PostController(IPostProvider postProvider,IPostService postService)
        {
            _postProvider = postProvider;
            _postService = postService;
        }

        [HttpGet]
        public Task<IReadOnlyCollection<PostResponse>> Get([FromQuery]PostEntityFilterModel model, CancellationToken ct) 
        {
            return _postProvider.GetAsync(model, ct);
        }

        [HttpGet("{id:int}")]
        public Task<PostResponse> GetById(int id,CancellationToken ct)
        {
            return _postService.GetByIdAsync(id, ct);
        }

        [HttpPost]
       // [Authorize]
        public Task<PostResponse> Create(PostRequest post,CancellationToken ct)
        {
            return _postService.CreateAsync(post, ct);
        }

        [HttpDelete]
      //  [Authorize]
        public Task<bool> Delete(int id, CancellationToken ct)
        {
            return _postService.DeleteAsync(id, ct);
        }
        
        [HttpPut]
       // [Authorize]
        public Task<PostResponse> Update(PostRequest post,int postId,CancellationToken ct)
        {
            return _postService.UpdateAsync(postId, post, ct);
        }



    }
}
