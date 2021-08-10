using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class LikeRepository: GenericRepository<LikeEntity>, ILikeRepositoryAsync
    {
        public LikeRepository(RepositoryContext db) : base(db) { }

    }
}
