using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<UserResponse> GetByIdAsync(int id, CancellationToken ct);
        Task<UserResponse> CreateAsync(UserRequest model, CancellationToken ct = default);
        Task<UserResponse> GetByAuthIdAsync(string userAuthId, CancellationToken ct = default);
    }
}
