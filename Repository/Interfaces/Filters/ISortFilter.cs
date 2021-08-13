using Snippet.Data.Entities.Base;
using System;
using System.Linq;

namespace Snippet.Data.Interfaces.Filters
{
    public interface ISortFilter<TEntity> where TEntity : BaseEntity
    {
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> SortFunc { get; set; }
    }
}
