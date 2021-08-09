﻿using Services.Models;
using Services.Models.RequestModels;
using Snippet.Data.Entities;
using System;
using System.Collections.Generic;


namespace Snippet.BLL.Models.FilterModels
{
    public class PostFiltersRequest
    {
        public int Skip { get; set; } = 0;
        public int Count { get; set; } = 1;

        public DateTime? From { get; set; } = default;
        public DateTime? To { get; set; } = default;

        public IEnumerable<UserRequest> IncludeUsers { get; set; } = default;
        public IEnumerable<UserRequest> ExcludeUsers { get; set; } = default;

        public ICollection<string> Tags { get; set; } = default;

        public IEnumerable<int> Languages { get; set; } = default;

    }
}
