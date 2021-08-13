using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentProvider _commentProvider;

        public CommentController(ICommentProvider commentProvider)
        {
            _commentProvider = commentProvider;
        }
        [HttpGet("{postId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<IReadOnlyCollection<CommentResponse>> GetAllByPostId(int postId, int skip = 0, int count = int.MaxValue, CancellationToken ct = default)
        {
            return _commentProvider.GetAllByPostIdAsync(postId, skip, count, ct);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CommentResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize]
        public async Task<IActionResult> Create([FromBody]CommentRequest comment, CancellationToken ct = default)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _commentProvider.CreateAsync(comment, ct);
            if(result == null)
            {
                return BadRequest("Wrong father id");
            }
            return Created(Url.Content("~/"), result);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // [Authorize]
        public Task<bool> Delete(int id, CancellationToken ct = default)
        {
            return _commentProvider.DeleteAsync(id, ct);
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody]CommentRequest comment, CancellationToken ct = default)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _commentProvider.UpdateAsync(id, comment, ct);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
