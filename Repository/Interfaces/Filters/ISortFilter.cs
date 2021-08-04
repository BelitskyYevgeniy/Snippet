using Snippet.Data.Entities.Base;
using Snippet.Data.Filters.Enums;
using System;
using System.Linq;

namespace Snippet.Data.Interfaces.Filters
{
    public interface ISortFilter<TEntity> where TEntity : BaseEntity
    {
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> SortField { get; }
    }
}
