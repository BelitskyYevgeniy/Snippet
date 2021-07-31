using Snippet.BLL.Interfaces.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snippet.BLL.Models.RequestModels
{
    public class FiltersRequestModel
    {
        public DateTime From { get; set; } = default;
        public DateTime To { get; set; } = default;

        public IEnumerable<User> IncludeUsers { get; set; } = default;
        public IEnumerable<User> ExcludeUsers { get; set; } = default;

        public IEnumerable<Tag> Tags { get; set; } = default;

        public Language Language { get; set; } = default;

        public ISortFilter<Post> SortFilter { get; set; } = default;
    }
}
