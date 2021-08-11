using Services.Models.RequestModels;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILikeProvider
    {
        Task<LikeRequest> CreateAsync(LikeRequest like,CancellationToken ct = default);
        Task<int> GetCountAsync(int postId, CancellationToken ct = default);
        Task<IReadOnlyCollection<LikeEntity>> GetAllByPostAsync(int postId, CancellationToken ct = default);
        Task DeleteLikesOfPostAsync(int postId, CancellationToken ct = default);
    }
}
