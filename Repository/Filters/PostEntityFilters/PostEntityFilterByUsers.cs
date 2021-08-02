using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snippet.Data.Filters.PostEntityFilters
{
    class PostEntityFilterByUsers : IFilter<PostEntity>
    {
        public IEnumerable<UserEntity> Include { get; private set; }
        public IEnumerable<UserEntity> Exclude { get; private set; }
        public PostEntityFilterByUsers(IEnumerable<UserEntity> include, IEnumerable<UserEntity> exclude)
        {
            if(include == null || exclude == null)
            {
                throw new CreationFilterException("include(IEnumerable<UserEntity>) || include(IEnumerable<UserEntity>) = null!");
            }
            Include = new HashSet<UserEntity>(include);
            Exclude = new HashSet<UserEntity>(exclude);
        }
        public Predicate<PostEntity> Predicate => (PostEntity post) => Include.Any(user => user.Id == post.UserId) && Exclude.All(user => user.Id != post.UserId);

        public int Degree { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
