﻿using Snippet.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class LikeEntity: BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int PostId { get; set; }

    }
}
