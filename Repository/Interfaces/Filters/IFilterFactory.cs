using System.Collections.Generic;

namespace Snippet.Data.Interfaces.Filters
{
    public interface IFilterFactory<T> where T : class
    {
        IReadOnlyCollection<IFilter<T>> CreateFilters(object obj);
    }
}
