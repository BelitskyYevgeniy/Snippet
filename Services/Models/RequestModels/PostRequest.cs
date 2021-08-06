using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models.RequestModels
{
    public class PostRequest
    {
        [Required]
        public int Id { get; set; }

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

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
