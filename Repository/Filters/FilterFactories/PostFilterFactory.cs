using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Filters.PostEntityFilters;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snippet.Data.Filters.FilterFactories
{
    class PostFilterFactory : IFilterFactory<PostEntity>
    {
        private PostEntityFilterByDateTime PostEntityFilterByDateTime(PostEntityFilterModel model)
        {
            return new PostEntityFilterByDateTime(model.From, model.To);
        }
        public IEnumerable<IFilter<PostEntity>> CreateFilter(object obj)
        {
            if(!(obj is PostEntityFilterModel))
            {
                throw new CreationFilterFactoryException("PostFilterFactory can not create filters from not PostEntityFilterModel!");
            }
           
        }
    }
}
