using Services.Models;
using Snippet.Data.Interfaces.Generic;
using SnippetWebAPI.Interfaces.Filters;
using SnippetWebAPI.Interfaces.Providers;
using System;
using System.Collections.Generic;


namespace Services.Providers
{
    //public class SearchPostsProvider : ISearchProvider<Post>
    //{
    //    private readonly IEnumerable<IFilter<Post>> _filters;
    //    private readonly char _separator = ';';
    //    public IEnumerable<IFilter<Post>> Filters => _filters;
    //    public SearchPostsProvider()
    //    {
    //        _filters = new List<IFilter<Post>>();
    //    }
    //    public void Deserialize(object parameters)
    //    {
            
    //        var par = (string[])parameters;
    //        foreach (var str in par)
    //        {
                
    //        }

    //    }

    //    public IEnumerable<Post> Search(IGenericRepositoryAsync<Post> repository)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
