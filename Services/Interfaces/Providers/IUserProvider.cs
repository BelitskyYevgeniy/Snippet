using Services.Models;
using Services.Models.ResponseModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<UserResponse> GetByIdAsync(int id, CancellationToken ct);
    }
}
