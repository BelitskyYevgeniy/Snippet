using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;

namespace Snippet.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepositoryAsync
    {
        public UserRepository(RepositoryContext dbContext) : base(dbContext)
        { }
    }
}
