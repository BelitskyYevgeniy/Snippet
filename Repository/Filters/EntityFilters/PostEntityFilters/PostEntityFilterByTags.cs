using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Snippet.Data.Filters.EntityFilters.PostEntityFilters
{
    public class PostEntityFilterByTags: IFilter<PostEntity>
    {
        public IEnumerable<string> Tags { get; private set; }

        public Expression<Func<PostEntity, bool>> Predicate => (PostEntity post) => post.PostTags.Any(pt => Tags.Contains(pt.Tag.Name));

        public int Degree { get; set; }

        public PostEntityFilterByTags(IEnumerable<string> tags)
        {
            if(tags == null)
            {
                throw new CreationFilterException("Tags can not equal null!");
            }
            Tags = new HashSet<string>(tags);
        }

    }
}
