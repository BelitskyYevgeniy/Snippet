using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Post
    {
       // [Key]
        public int Id { get; set; }

        public int? UserId { get; set; } = default;

        [Required]
        [MaxLength(1024)]
        public string Tittle { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(4096)]
        public string SnippetCode { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime LastUpdateDateTime { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
