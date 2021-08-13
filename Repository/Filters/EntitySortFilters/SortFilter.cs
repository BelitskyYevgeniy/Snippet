using Snippet.Data.Entities.Base;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snippet.Data.Filters.EntitySortFilters
{
    public class SortFilter<TEntity> : ISortFilter<TEntity> where TEntity : BaseEntity
    {
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> SortFunc { get; set; }
    }
}
