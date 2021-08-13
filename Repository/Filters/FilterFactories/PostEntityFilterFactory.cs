using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Filters.EntityFilters.PostEntityFilters;
using Snippet.Data.Interfaces.Filters;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Snippet.Data.Filters.FilterModels.Base;

namespace Snippet.Data.Filters.FilterFactories
{
    class PostEntityFilterFactory : IFilterFactory<PostEntity>
    {
        public IReadOnlyCollection<IFilter<PostEntity>> CreateFilters(FilterModel obj)
        {
            if(!(obj is PostEntityFilterModel))
            {
                throw new CreationFilterFactoryException("PostEntityFilterFactory can not create filters from not PostEntityFilterModel!");
            }
            var result = new List<IFilter<PostEntity>>();
            PostEntityFilterModel model = (PostEntityFilterModel)obj;
            if(model.Tags != null && model.Tags.Count() != 0)
            {
                var entity = new PostEntityFilterByTags(model.Tags);
                entity.Degree = 1;
                result.Add(entity);
            }

            if (model.Languages != null && model.Languages.Count() != 0)
            {
                var entity = new PostEntityByLanguages(model.Languages);
                entity.Degree = 10;
                result.Add(entity);
            }

            bool isNotEmptyInclude = (model.Include != null);
            bool isNotEmptyExclude = (model.Exclude != null);
            if (isNotEmptyInclude || isNotEmptyExclude)
            {
                model.Include = isNotEmptyInclude ? model.Include : new List<int>();
                model.Exclude = isNotEmptyExclude ? model.Include : new List<int>();
                var entity = new PostEntityFilterByUsers(model.Include, model.Exclude);
                entity.Degree = 3;
                result.Add(entity);
            }

            if (model.To != null || model.From != null)
            {
                var entity = new PostEntityFilterByDateTime(model.From, model.To);
                entity.Degree = 8;
                result.Add(entity);
            }

            if(!string.IsNullOrWhiteSpace(model.SearchingText))
            {
                var entity = new PostEntityFilterByTextSearch(model.SearchingText);
                entity.Degree = 0;
                result.Add(entity);
            }

            return new ReadOnlyCollection<IFilter<PostEntity>>(result.OrderByDescending(post => post.Degree).ToList());
        }
    }
}
