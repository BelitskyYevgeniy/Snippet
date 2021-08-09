using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels.Base;

namespace Snippet.Data.Interfaces.Filters
{
    public interface ISortFilterFactory
    {
        ISortFilter<PostEntity> Create(FilterModel obj);
    }
}
