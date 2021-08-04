using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterFactories;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Filters.PostEntityFilters;
using Snippet.Data.Interfaces.Filters;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class PostRepository: GenericRepository<PostEntity>, IPostRepositoryAsync
    {
        public PostRepository(RepositoryContext db): base(db)
        {
            
        }

        public Task<IReadOnlyCollection<PostEntity>> FindAsync(PostEntityFilterModel model, CancellationToken ct = default)
        {
            var factory = new PostFilterFactory();
            var filters = factory.CreateFilters(model).OrderBy(filter => filter.Degree);
            IQueryable<PostEntity> query = _dbContext.Posts;
            Func<PostEntity, bool> func =
            delegate (PostEntity post)
            {
                foreach (var filter in filters)
                {
                    if (!filter.Predicate(post))
                    {
                        return false;
                    }
                }
                return true;
            };
            return FindAsync(model.Count, model.Start, func, model.SortFilter.SortField, new string[] { "Tags"}, ct);
        }
    }
}
