using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class CommentRepository: GenericRepository<CommentEntity>, ICommentRepositoryAsync
    {
        public CommentRepository(RepositoryContext db) : base(db) { }

        public async Task RemoveAllByPostId(int postId, CancellationToken ct = default)
        {
            var comments = await FindAsync(0, await GetCount(ct), false,
            new List<Expression<Func<CommentEntity, bool>>>()
            {
                comment => comment.PostId == postId
            }, null, null, ct);

            _dbContext.RemoveRange(comments);
        }
    }
}
