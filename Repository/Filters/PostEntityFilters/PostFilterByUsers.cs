using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snippet.Data.Filters.PostEntityFilters
{
    class PostFilterByUsers : IFilter<PostEntity>
    {
        public IEnumerable<UserEntity> Include { get; private set; }
        public IEnumerable<UserEntity> Exclude { get; private set; }
        public PostFilterByUsers(IEnumerable<UserEntity> include, IEnumerable<UserEntity> exclude)
        {

        }
        public Predicate<PostEntity> Predicate => throw new NotImplementedException();

        public int Degree { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
