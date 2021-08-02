using System.Collections.Generic;

namespace Snippet.Data.Interfaces.Filters
{
    public interface IFilterFactory<T> where T : class
    {
        IEnumerable<IFilter<T>> CreateFilter(object obj);
    }
}
