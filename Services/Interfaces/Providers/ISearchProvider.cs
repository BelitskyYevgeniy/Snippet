using Repository.Interfaces;
using SnippetWebAPI.Interfaces.Filters;
using System.Collections.Generic;

namespace SnippetWebAPI.Interfaces.Providers
{
    public interface ISearchProvider<T> where T : class
    {
        IEnumerable<IFilter<T>> Filters { get; }
        IEnumerable<T> Search(IGenericRepositoryAsync<T> repository);
        void Deserialize(object parameters);
    }
}
