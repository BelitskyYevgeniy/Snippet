namespace SnippetWebAPI.Interfaces.Filters
{
    public interface IFilterFactory<T> where T: class
    {
        IFilter<T> CreateFilter(object obj);
    }
}
