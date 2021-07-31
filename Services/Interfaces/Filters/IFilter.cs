using System;

namespace SnippetWebAPI.Interfaces.Filters
{
    public interface IFilter<T>
    {
        Predicate<T> Predicate { get; }
        int Degree { get; set; }
        string FilterName { get; set; }
    }
}
