using Snippet.Data.Filters.EntitySortFilters;

namespace Snippet.Data.Filters.FilterModels.Base
{
    public class FilterModel: PaginationModel
    {
        public string SortField { get; set; } = default;
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
