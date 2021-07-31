using Snippet.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippet.Data.Entities
{
    public class PostEntity : BaseEntity
    {
        [Required]
        [MaxLength(1024)]
        public string Tittle { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        [MaxLength(4096)]
        public string SnippetCode { get; set; }
        [Required]
        [ForeignKey(nameof(Language))]
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        List<TagEntity> Tags { get; set; } = new List<TagEntity>();


    }
}
