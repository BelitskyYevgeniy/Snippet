using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;

namespace Snippet.Data.Repositories
{
    public class PostRepository: GenericRepository<PostEntity>, IPostRepositoryAsync
    {
        public PostRepository(RepositoryContext db): base(db)
        {

        }
    }
}
