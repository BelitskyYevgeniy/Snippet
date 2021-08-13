using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Snippet.Data.Filters.EntityFilters.PostEntityFilters
{
    class PostEntityFilterByTextSearch : IFilter<PostEntity>
    {
        public string SearchingText { get; private set; }
        public PostEntityFilterByTextSearch(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                throw new CreationFilterException("texts can not be null or empty or consist only of white-space characters!");
            }
            SearchingText = text.Trim();
        }
        public Expression<Func<PostEntity, bool>> Predicate => 
            p => p.Tittle.Contains(SearchingText) ||
            p.Description.Contains(SearchingText) ||
            p.SnippetCode.Contains(SearchingText);

        public int Degree { get; set; }
    }
}
