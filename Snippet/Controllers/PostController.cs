using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models;
using Services.Responses;
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
        public Task<IReadOnlyCollection<PostResponse>> GetAll(CancellationToken ct) 
        {
            return _postService.GetAll(ct);
        }

        [HttpGet("{id:int}")]
        public Task<PostResponse> GetById(int id,CancellationToken ct)
        {
            return _postService.GetByIdAsync(id, ct);
        }

        [HttpPost]
        [Authorize]
        public Task<Post> Create(Post post,CancellationToken ct)
        {
            return _postProvider.MakeAsync(post, ct);
        }

        [HttpDelete]
        [Authorize]
        public Task<bool> Delete(int id, CancellationToken ct)
        {
            return _postProvider.DeleteAsync(id, ct);
        }
        
        [HttpPut]
        [Authorize]
        public Task<Post> Update(Post post,CancellationToken ct)
        {
            return _postProvider.UpdateAsync(post, ct);
        }



    }
}
