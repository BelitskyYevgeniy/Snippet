using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;

namespace Snippet.Data.Repositories
{
    public class LikeRepository: GenericRepository<LikeEntity>, ILikeRepositoryAsync
    {
        public LikeRepository(RepositoryContext db) : base(db) { }
    }
}
