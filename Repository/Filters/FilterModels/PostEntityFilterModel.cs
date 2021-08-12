using Snippet.Data.Entities;
using Snippet.Data.Filters.FilterModels.Base;
using System;
using System.Collections.Generic;

namespace Snippet.Data.Filters.FilterModels
{
    public class PostEntityFilterModel: FilterModel
    {
        public DateTime? From { get; set; } = null;
        public DateTime? To { get; set; } = null;

        public IEnumerable<string> Tags { get; set; } = default;

        public IEnumerable<int> Include { get; set; } = default;
        public IEnumerable<int> Exclude { get; set; } = default;


        public IEnumerable<int> Languages { get; set; } = default;

        public string SearchingText { get; set; } = string.Empty;
    }
}
