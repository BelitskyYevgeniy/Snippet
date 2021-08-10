using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models.RequestModels
{
    public class PostRequest
    {

        [Required]
        [MaxLength(1024, ErrorMessage = "Tittle size can not be more than 1024 bytes")]
        public string Tittle { get; set; }

        [MaxLength(2048, ErrorMessage = "Description size can not be more than 2048 bytes")]
        public string Description { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(4096, ErrorMessage = "Code size can not be more than 4096 bytes")]
        public string SnippetCode { get; set; }

        public List<TagRequest> Tags { get; set; } = new List<TagRequest>();
    }
}
