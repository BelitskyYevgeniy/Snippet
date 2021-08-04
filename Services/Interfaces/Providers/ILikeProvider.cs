using Services.Models;
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
        public Task<Like> CreateAsync(Like like,CancellationToken ct = default);
        public Task<bool> RemoveAsync(Like like, CancellationToken ct = default);
        public Task<int> GetCountAsync(int postId, CancellationToken ct = default);

    }
}
