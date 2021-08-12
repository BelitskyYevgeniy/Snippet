using Services.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface ILikeService
    {
        Task<bool> CreateAsync(LikeRequest like, CancellationToken ct = default);
    }
}
