using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Filters.PostEntityFilters;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Snippet.Data.Filters.FilterFactories
{
    class PostFilterFactory : IFilterFactory<PostEntity>
    {
        private PostEntityFilterByDateTime PostEntityFilterByDateTime(PostEntityFilterModel model)
        {
            return new PostEntityFilterByDateTime(model.From, model.To);
        }
        public IReadOnlyCollection<IFilter<PostEntity>> CreateFilter(object obj)
        {
            if(!(obj is PostEntityFilterModel))
            {
                throw new CreationFilterFactoryException("PostFilterFactory can not create filters from not PostEntityFilterModel!");
            }
            var result = new List<IFilter<PostEntity>>();
            PostEntityFilterModel model = (PostEntityFilterModel)obj;
            if(model.Tags != null && model.Tags.Count() != 0)
            {
                result.Add(new PostEntityFilterByTags(model.Tags));
            }

            if (model.Languages != null && model.Languages.Count() != 0)
            {
                result.Add(new PostEntityByLanguages(model.Languages));
            }

            if (model.Include != null && model.Exclude != null)
            {
                result.Add(new PostEntityFilterByUsers(model.Include, model.Exclude));
            }

            if (model.To != null && model.From != null)
            {
                result.Add(new PostEntityFilterByDateTime(model.From, model.To));
            }

            return new ReadOnlyCollection<IFilter<PostEntity>>(result.OrderBy(post => post.Degree).ToList());
        }
    }
}
