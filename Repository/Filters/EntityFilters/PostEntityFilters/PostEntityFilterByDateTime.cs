using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Linq.Expressions;

namespace Snippet.Data.Filters.EntityFilters.PostEntityFilters
{
    public class PostEntityFilterByDateTime : IFilter<PostEntity>
    {

        public PostEntityFilterByDateTime(DateTime? from, DateTime? to)
        {
            if (from == null && to == null)
            {
                throw new CreationFilterException("Arguments(DateTime?) can not equal null at the same time!");
            }
            From = from == null ? DateTime.MinValue : (DateTime)from;
            To = to == null ? DateTime.MaxValue : (DateTime)to;
            if (To < From)
            {
                throw new CreationFilterException("(DateTime)From can not be more than (DateTime)to");
            }
            
        }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public Expression<Func<PostEntity, bool>> Predicate => (PostEntity post) => From <= post.LastUpdateDateTime && post.LastUpdateDateTime <= To;

        public int Degree { get; set; }
    }
}
