using Snippet.Data.Entities;
using Snippet.Data.Filters.EntitySortFilters;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Filters.FilterModels;
using Snippet.Data.Filters.FilterModels.Base;
using Snippet.Data.Interfaces.Filters;
using System.Linq;

namespace Snippet.Data.Filters.SortFilterFactories
{
    public class PostEntitySortFilterFactory : ISortFilterFactory
    {
        public ISortFilter<PostEntity> Create(FilterModel obj)
        {
            if(!(obj is PostEntityFilterModel))
            {
                throw new CreationFilterFactoryException("PostEntitySortFilterFactory can not create filters from not PostEntityFilterModel");
            }
            var model = (PostEntityFilterModel)obj;
            if(model.SortField == null)
            {
                return null;
            }
            var filter = new SortFilter<PostEntity>();
            switch (model.SortField)
            {
                 case "likes":
                    {
                        if(model.SortDirection == SortDirection.Ascending)
                        {
                            filter.SortFunc = q => q.OrderBy(post => post.Likes.Count);
                        }
                        else
                        {
                            filter.SortFunc = q => q.OrderByDescending(post => post.Likes.Count);
                        }
                }; break;
                case "creationDateTime":
                    {
                        if (model.SortDirection == SortDirection.Ascending)
                        {
                            filter.SortFunc = q => q.OrderBy(post => post.CreationDateTime);
                        }
                        else
                        {
                            filter.SortFunc = q => q.OrderByDescending(post => post.CreationDateTime);
                        }
                    }; break;
                default: return null;
            }
            return filter;
        }
    }
}
