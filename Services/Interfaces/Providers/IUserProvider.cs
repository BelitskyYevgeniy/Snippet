using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<User> GetById(int id, CancellationToken ct);
    }
}
