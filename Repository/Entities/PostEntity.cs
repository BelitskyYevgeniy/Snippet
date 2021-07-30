using Snippet.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippet.Data.Entities
{
    public class PostEntity : BaseEntity
    {
        [Required]
        public string Tittle { get; set; }

        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        [ForeignKey(nameof(Language))]
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        List<TagEntity> Tags { get; set; } = new List<TagEntity>();


    }
}
