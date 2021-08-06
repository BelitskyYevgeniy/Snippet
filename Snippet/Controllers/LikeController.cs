using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models;
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
       // [Authorize]
        public async Task<bool> PressLike(Like like,CancellationToken ct)
        {
            var newLike = await _likeProvider.CreateAsync(like, ct).ConfigureAwait(false);

            return newLike == null ? false:true;
        }
        [HttpGet]
        public Task<int> GetRaiting(int postId, CancellationToken ct)
        {
            return _likeProvider.GetCountAsync(postId, ct);
        }
    }
}
