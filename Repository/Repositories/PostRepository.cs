﻿using Microsoft.EntityFrameworkCore;
using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterFactories;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Filters.SortFilterFactories;
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
            var factory = new PostEntityFilterFactory();
            var sortFactory = new PostEntitySortFilterFactory();
            var filters = factory.CreateFilters(model).OrderBy(filter => filter.Degree);
            var expressions = new List<Expression<Func<PostEntity, bool>>>();
            foreach(var filter in filters)
            {
                expressions.Add(filter.Predicate);
            }
            var sortFilter = sortFactory.Create(model);
            Func<IQueryable<PostEntity>, IOrderedQueryable <PostEntity>> sortFunc = null;
            if(sortFilter != null)
            {
                sortFunc = sortFilter.SortFunc;
            }

            return FindAsync(model.Skip, model.Count, expressions, sortFunc,
                e => e.Include(e => e.Language)
                .Include(e => e.User)
                .Include(e => e.PostTags)
                .ThenInclude(e => e.Tag), ct);
        }
        public override async Task<PostEntity> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var result = await FindAsync(0, 1, new List<Expression<Func<PostEntity, bool>>>() { post => post.Id == id }, null,
                e => e.Include(e => e.Language)
               .Include(e => e.PostTags)
               .ThenInclude(e => e.Tag)
               .Include(e => e.User), ct);
            if (result == null || result.Count() == 0)
            {
                return null;
            }
            return result.ElementAt(0);
        }
    }
}
