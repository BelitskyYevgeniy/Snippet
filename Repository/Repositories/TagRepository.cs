using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;

namespace Snippet.Data.Repositories
{
    public class TagRepository : GenericRepository<TagEntity>, ITagRepositoryAsync
    {
        public TagRepository(RepositoryContext db) : base(db) { }
    }

}
