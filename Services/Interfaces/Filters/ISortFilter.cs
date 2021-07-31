using SnippetWebAPI.Interfaces.Filters;

namespace Snippet.BLL.Interfaces.Filters
{
    public interface ISortFilter<T> :IFilter<T> where T: class
    {

    }
}
