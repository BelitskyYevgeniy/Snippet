using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepositoryAsync
    {
        public UserRepository(RepositoryContext dbContext) : base(dbContext)
        { }

        public override async Task<bool> ValidateEntity(UserEntity entity, CancellationToken ct = default)
        {
            if(!(entity == null || entity.Name == null || entity.Name.Length < 1 || entity.AuthId == null))
            {
                return false;
            }
            var existingUser = (await FindAsync(filters:
                new List<Expression<Func<UserEntity, bool>>>() { e => e.AuthId == entity.AuthId || e.Name == entity.Name },
                ct: ct)).FirstOrDefault();

            return existingUser != null;
        }
    }
}
