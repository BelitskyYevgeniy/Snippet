using Snippet.Data.Entities;
using System;
using System.Collections.Generic;

namespace Snippet.Data.Filters.FilterModels
{
    class PostEntityFilterModel
    {
        public DateTime? From { get; set; } = null;
        public DateTime? To { get; set; } = null;

        public IEnumerable<TagEntity> Tags { get; set; } = default;

        public IEnumerable<UserEntity> Include { get; set; } = default;
        public IEnumerable<UserEntity> Exclude { get; set; } = default;


        public IEnumerable<LanguageEntity> Languages { get; set; } = default;

    }
}
