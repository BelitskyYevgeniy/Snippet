using Services.Models;
using System;
using System.Collections.Generic;


namespace Snippet.BLL.Models.FilterModels
{
    public class PostFiltersModel
    {
        int Skip { get; set; } = 0;
        int Count { get; set; } = 1;

        public DateTime? From { get; set; } = default;
        public DateTime? To { get; set; } = default;

        public IEnumerable<User> IncludeUsers { get; set; } = default;
        public IEnumerable<User> ExcludeUsers { get; set; } = default;

        public IEnumerable<Tag> Tags { get; set; } = default;

        public Language Language { get; set; } = default;

    }
}
