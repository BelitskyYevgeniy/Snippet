using Microsoft.EntityFrameworkCore;
using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class LikeRepository: GenericRepository<LikeEntity>, ILikeRepositoryAsync
    {
        public LikeRepository(RepositoryContext db) : base(db) { }

        public override async Task<bool> ValidateEntity(LikeEntity entity, CancellationToken ct = default)
        {
            var post = await _dbContext.Posts.Where(e => e.Id == entity.PostId).FirstOrDefaultAsync();
            if (post == null)
            {
                return false;
            }

            var user = await _dbContext.Users.Where(e => e.Id == entity.UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
