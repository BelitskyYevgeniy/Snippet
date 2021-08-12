using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.Data.Interfaces.Repositories;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    [Authorize]
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserProvider _userProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticationService(IHttpContextAccessor httpContextAccessor, IUserProvider userProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _userProvider = userProvider;
        }
        public Task<UserResponse> GetUserAsync(CancellationToken ct = default)
        {
            var userAuthId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _userProvider.GetByAuthIdAsync(userAuthId, ct);
        }
        public async Task<UserResponse> RegisterUserAsync(CancellationToken ct = default)
        {
            var response = await GetUserAsync(ct);
            if(response != null)
            {
                return response;
            }
            var request = new UserRequest
            {
                Name = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
                AuthId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
            };
            return await _userProvider.CreateAsync(request, ct);
        }
    }
}
