﻿using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class PostTagEntity
    {
        [Required]
        public int PostId { get; set; }
        public PostEntity Post { get; set; }

        [Required]
        public int TagId { get; set; }
        public TagEntity Tag { get; set; }
    }
}
