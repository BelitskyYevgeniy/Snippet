using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.BLL.Models
{
    public class Post
    {
       [Key]
        public int Id { get; set; }

        [Required]
        public User Owner { get; set; }

        [Required]
        public string Tittle { get; set; }

        public string Description { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        public string SnippetCode { get; set; } 
        
        public List<Like> Likes { get; set; } = new List<Like>();
    }
}
