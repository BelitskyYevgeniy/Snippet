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
        public void Like(Like like,CancellationToken ct);
        public void RemoveLike(Like like, CancellationToken ct);
    }
}
