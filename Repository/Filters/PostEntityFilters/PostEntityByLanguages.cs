using Snippet.Data.Entities;
using Snippet.Data.Filters.Exceptions;
using Snippet.Data.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snippet.Data.Filters.PostEntityFilters
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
        public Predicate<PostEntity> Predicate => (PostEntity post) => Languages.Any(language => language.Id == post.LanguageId);

        public int Degree { get; set; }
    }
}
