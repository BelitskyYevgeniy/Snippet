using System;

namespace Snippet.Data.Interfaces.Filters
{
    public interface IFilter<T>
    {
        Predicate<T> Predicate { get; }
        int Degree { get; set; }
    }
}