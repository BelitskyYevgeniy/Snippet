using Snippet.Data.Context;
using Snippet.Data.Entities;

namespace Snippet.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>
    {
        public UserRepository(RepositoryContext dbContext) : base(dbContext)
        { }
    }
}
