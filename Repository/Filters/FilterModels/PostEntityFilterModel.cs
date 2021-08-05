using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels.Base;
using System;
using System.Collections.Generic;

namespace Snippet.Data.Filters.FilterModels
{
    public class PostEntityFilterModel: FilterModel<PostEntity>
    {
        public DateTime? From { get; set; } = null;
        public DateTime? To { get; set; } = null;

        public IEnumerable<TagEntity> Tags { get; set; } = default;

        public IEnumerable<UserEntity> Include { get; set; } = default;
        public IEnumerable<UserEntity> Exclude { get; set; } = default;


        public IEnumerable<LanguageEntity> Languages { get; set; } = default;


    }
}
