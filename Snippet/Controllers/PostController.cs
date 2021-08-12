using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.Data.Filters.FilterModels;
using System;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<PostResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery]PostEntityFilterModel model, CancellationToken ct = default) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _postProvider.GetAsync(model, ct);
            if(response == null)
            {
                return BadRequest("Model is not valid");
            }
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<PostResponse> GetById(int id, CancellationToken ct = default)
        {
            return _postService.GetByIdAsync(id, ct);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PostResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize]
        public async Task<IActionResult> Create([FromBody]PostRequest post, CancellationToken ct = default)
        {
            if(!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            var response = await _postService.CreateAsync(post, ct);
            if(response == null)
            {
                return BadRequest("Model is not valid");
            }
            return Created(Url.Content("~/") , response);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        //  [Authorize]
        public Task<bool> Delete(int id, CancellationToken ct = default)
        {
            return _postService.DeleteAsync(id, ct);
        }
        
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody]PostRequest post, CancellationToken ct = default)
        {
            if (!(ModelState.IsValid))
            {
                return BadRequest(ModelState);
            }
            var response = await _postService.UpdateAsync(id, post, ct);
            if (response == null)
            {
                return BadRequest("Model is not valid");
            }
            return Ok(response);
        }

        [HttpGet("Count")]
        public Task<int> GetCount(CancellationToken ct)
        {
            return _postProvider.GetCount(ct);
        }

    }
}
