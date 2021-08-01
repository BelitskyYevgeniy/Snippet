using Services.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Post:BaseModel
    {
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
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
