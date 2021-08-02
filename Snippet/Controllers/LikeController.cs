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
        public Task<Like> Like(Like like,CancellationToken ct)
        {
            return _likeProvider.Like(like,ct);
        }
    }
}
