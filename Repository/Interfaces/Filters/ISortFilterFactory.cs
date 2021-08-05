using Snippet.Data.Entities;

namespace Snippet.Data.Interfaces.Filters
{
    public interface ISortFilterFactory
    {
        ISortFilter<PostEntity> Create(object obj);
    }
}
