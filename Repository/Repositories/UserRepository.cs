using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepositoryAsync
    {
        public UserRepository(RepositoryContext dbContext) : base(dbContext)
        { }

        public override Task<bool> ValidateEntity(UserEntity entity, CancellationToken ct = default)
        {
            return Task.FromResult(!(entity == null || entity.Name == null || entity.Name.Length < 1));
        }
    }
}
