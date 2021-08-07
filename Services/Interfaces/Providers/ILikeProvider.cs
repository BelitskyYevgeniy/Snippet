using Services.Models;
using Services.Models.RequestModels;
using Snippet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface ILikeProvider
    {
        public Task<LikeRequest> CreateAsync(LikeRequest like,CancellationToken ct = default);
        public Task<bool> RemoveAsync(int likeId, CancellationToken ct = default);
        public Task<int> GetCountAsync(int postId, CancellationToken ct = default);

    }
}
