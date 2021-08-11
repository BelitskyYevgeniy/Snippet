using Microsoft.AspNetCore.Http;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<UserResponse> GetUserAsync(HttpContext context, CancellationToken ct = default);
        Task<UserResponse> RegisterUser(HttpContext context, CancellationToken ct = default);
    }
}
