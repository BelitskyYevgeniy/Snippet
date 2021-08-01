using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snippet.Data.Filters.PostEntityFilters
{
    public class PostEntityFilterByTags: IFilter<PostEntity>
    {
        public IEnumerable<TagEntity> Tags { get; private set; }

        public Predicate<PostEntity> Predicate => (PostEntity post) => post.Tags.Intersect(Tags).Count() == Tags.Count();

        public int Degree { get; set; }

        public PostEntityFilterByTags(IEnumerable<TagEntity> tags)
        {
            if(tags == null)
            {
                throw new CreationFilterException("Tags can not equal null!");
            }
            Tags = tags;
        }

    }
}
