using Snippet.Data.Entities;
using System;
using System.Collections.Generic;

namespace Snippet.Data.Filters.FilterModels
{
    class PostEntityFilterModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public IEnumerable<TagEntity> Tags { get; set; }

        public IEnumerable<UserEntity> Include { get; set; }
        public IEnumerable<UserEntity> Exclude { get; set; }

        public IEnumerable<LanguageEntity> Languages { get; set; }
    }
}
