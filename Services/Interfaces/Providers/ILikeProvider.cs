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
        public Task<Like> Like(Like like,CancellationToken ct);
        public Task<bool> RemoveLike(int likeId, CancellationToken ct);
        public Task<int> GetAllByPostAsync(int postId, CancellationToken ct);

    }
}
