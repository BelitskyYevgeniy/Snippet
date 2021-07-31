
using Snippet.Data.Entities.Base;
using Snippet.Data.Interfaces.Generic;
using SnippetWebAPI.Interfaces.Filters;
using System.Collections.Generic;

namespace SnippetWebAPI.Interfaces.Providers
{
    public interface ISearchProvider<T> where T : BaseEntity
    {
        IEnumerable<IFilter<T>> Filters { get; }
        IEnumerable<T> Search(IGenericRepositoryAsync<T> repository);
        void Deserialize(object parameters);
    }
}
