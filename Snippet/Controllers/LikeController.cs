using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikeController: ControllerBase
    {
        private readonly ILikeProvider _likeProvider;

        public LikeController(ILikeProvider likeProvider)
        {
            _likeProvider = likeProvider;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [Authorize]
        public async Task<IActionResult> PressLike([FromBody]LikeRequest like, CancellationToken ct)
        {
            if(like == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newLike = await _likeProvider.CreateAsync(like, ct).ConfigureAwait(false);

            var result = newLike == null ? false : true;
            return Ok(result);
        }
        [HttpGet("{postId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<int> GetRaiting(int postId, CancellationToken ct)
        {
            return _likeProvider.GetCountAsync(postId, ct);
        }
    }
}
