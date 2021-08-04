using Snippet.Data.Entities.Base;
using Snippet.Data.Interfaces.Filters;

namespace Snippet.Data.Filters.FilterModels.Base
{
    public class FilterModel<TEntity>: PaginationModel where TEntity: BaseEntity
    {
        public ISortFilter<TEntity> SortFilter { get; set; } = default;
    }
}
