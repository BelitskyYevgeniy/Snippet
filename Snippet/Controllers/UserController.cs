using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController :ControllerBase
    {
        private readonly IUserProvider _userProvider;
        private readonly IAuthenticationService _authorizationService;
        public UserController(IUserProvider userProvider, IAuthenticationService authorizationService)
        {
            _userProvider = userProvider;
            _authorizationService = authorizationService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public Task<UserResponse> GetById(int id, CancellationToken ct = default)
        {
            return _userProvider.GetByIdAsync(id, ct);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public Task<UserResponse> Register(CancellationToken ct = default)
        {
            return _authorizationService.RegisterUserAsync(ct);
        }
    }
}
