using Microsoft.EntityFrameworkCore;
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
            if(model == null)
            {
                return null;
            }
            var factory = new PostEntityFilterFactory();
            var sortFactory = new PostEntitySortFilterFactory();
            var filters = factory.CreateFilters(model);
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

            return FindAsync(model.Skip, model.Count, false, expressions, sortFunc,
                e => e.Include(e => e.Language)
                .Include(e => e.User)
                .Include(e => e.PostTags)
                .ThenInclude(e => e.Tag), ct);
        }
        public override async Task<PostEntity> GetByIdAsync(int id, bool toTrack = false, CancellationToken ct = default)
        {
            var result = await FindAsync(0, 1, toTrack, new List<Expression<Func<PostEntity, bool>>>() { post => post.Id == id }, null,
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

        public override async Task<bool> ValidateEntity(PostEntity entity, CancellationToken ct = default)
        {
            if (entity.Tittle == null || entity.Tittle.Length < 1 || entity.Tittle.Length > 1024 ||
               entity.Description == null || entity.Description.Length < 1 || entity.Description.Length > 2048 ||
               entity.SnippetCode == null || entity.SnippetCode.Length < 1 || entity.SnippetCode.Length > 4096 ||
               entity.LastUpdateDateTime < entity.CreationDateTime)
            {
                return false;
            }
            var lang = await _dbContext.Languages.Where(e => e.Id == entity.LanguageId).FirstOrDefaultAsync();
            if (lang == null)
            {
                return false;
            }

            var user = await _dbContext.Users.Where(e => e.Id == entity.UserId).FirstOrDefaultAsync();
            /*if (user == null)
            {
                return false;
            }*/
            return true;
        }
    }
}
