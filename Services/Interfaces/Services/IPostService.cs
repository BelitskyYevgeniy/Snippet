using Services.Models;
using Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Services
{
    public interface IPostService
    {
        Task<PostResponse> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyCollection<PostResponse>> GetAll(CancellationToken ct);

    }
}
