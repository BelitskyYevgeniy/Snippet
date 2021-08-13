using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models.ResponseModels
{
    public class PostResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public UserResponse User { get; set; }

        [Required]
        public LanguageResponse Language { get; set; }

        [Required]
        [MaxLength(4096)]
        public string SnippetCode { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Tittle { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime LastUpdateDateTime { get; set; }


        public List<TagResponse> Tags { get; set; } = new List<TagResponse>();
    }
}
