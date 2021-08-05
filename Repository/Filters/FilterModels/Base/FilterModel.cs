using Snippet.Data.Entities.Base;
using Snippet.Data.Filters.EntitySortFilters;

namespace Snippet.Data.Filters.FilterModels.Base
{
    public class FilterModel<TEntity>: PaginationModel where TEntity: BaseEntity
    {
        public string SortField { get; set; } = default;
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
