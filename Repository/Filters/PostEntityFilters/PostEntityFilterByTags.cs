using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snippet.Data.Filters.PostEntityFilters
{
    public class PostEntityFilterByTags: IFilter<PostEntity>
    {
        public IEnumerable<TagEntity> Tags { get; private set; }

        public Predicate<PostEntity> Predicate => (PostEntity post) => Tags.Intersect(post.Tags).Count() != 0;

        public int Degree { get; set; }

        public PostEntityFilterByTags(IEnumerable<TagEntity> tags)
        {
            if(tags == null)
            {
                throw new CreationFilterException("Tags can not equal null!");
            }
            Tags = new HashSet<TagEntity>(tags);
        }

    }
}
