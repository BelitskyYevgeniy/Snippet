using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Snippet.Data.Filters.EntityFilters.PostEntityFilters
{
    public class PostEntityByLanguages : IFilter<PostEntity>
    {
        public IEnumerable<LanguageEntity> Languages { get; private set; }
        public PostEntityByLanguages(IEnumerable<LanguageEntity>  languages)
        {
            if(languages == null)
            {
                throw new CreationFilterException("languages(IEnumerable<LanguageEntity>) = null!");
            }
            Languages = new HashSet<LanguageEntity>(languages).ToArray();
        }
        public Expression<Func<PostEntity, bool>> Predicate => (PostEntity post) => Languages.Any(language => language.Id == post.LanguageId);

        public int Degree { get; set; }
    }
}
