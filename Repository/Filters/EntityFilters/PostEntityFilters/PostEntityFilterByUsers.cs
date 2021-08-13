using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Snippet.Data.Filters.EntityFilters.PostEntityFilters
{
    class PostEntityFilterByUsers : IFilter<PostEntity>
    {
        public IEnumerable<int> Include { get; private set; }
        public IEnumerable<int> Exclude { get; private set; }
        public PostEntityFilterByUsers(IEnumerable<int> include, IEnumerable<int> exclude)
        {
            if(include == null || exclude == null)
            {
                throw new CreationFilterException("include(IEnumerable<int>) || exclude(IEnumerable<int>) = null!");
            }
            Include = new HashSet<int>(include).ToArray();
            Exclude = new HashSet<int>(exclude).ToArray();
        }
        public Expression<Func<PostEntity, bool>> Predicate => (PostEntity post) => Include.Any(id => id == post.UserId) && Exclude.All(id => id != post.UserId);

        public int Degree { get; set; }
    }
}
