﻿using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterFactories;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var factory = new PostEntityFilterFactory();
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
            return FindAsync(model.Start, model.Count, func, model.SortFilter.SortField, new string[] { "Tags", "Language", "User" }, ct);
        }
        public override async Task<PostEntity> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var result = await FindAsync(0, 1, post => post.Id == id, null, new string[] { "Tags", "Language", "User" }, ct);
            if (result == null || result.Count() == 0)
            {
                return null;
            }
            return result.ElementAt(0);
        }
    }
}
