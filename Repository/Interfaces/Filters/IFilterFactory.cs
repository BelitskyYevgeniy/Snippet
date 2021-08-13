using Snippet.Data.Entities.Base;
using Snippet.Data.Filters.FilterModels.Base;
using System.Collections.Generic;

namespace Snippet.Data.Interfaces.Filters
{
    public interface IFilterFactory<TEntity> where TEntity : BaseEntity
    {
        IReadOnlyCollection<IFilter<TEntity>> CreateFilters(FilterModel obj);
    }
}
