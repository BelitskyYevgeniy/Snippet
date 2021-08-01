using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;

namespace Snippet.Data.Repositories
{
    public class CommentRepository: GenericRepository<CommentEntity>, ICommentRepositoryAsync
    {
        public CommentRepository(RepositoryContext db) : base(db) { }
    }
}
