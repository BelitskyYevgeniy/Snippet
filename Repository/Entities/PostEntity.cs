using Snippet.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class PostEntity : BaseEntity
    {
        [Required]
        [MaxLength(1024)]
        public string Tittle { get; set; } = string.Empty;

        [MaxLength(2048)]
        public string Description { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        [MaxLength(4096)]
        public string SnippetCode { get; set; } = string.Empty;

        [Required]
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime LastUpdateDateTime { get; set; }
        public List<PostTagEntity> PostTags { get; set; } = new List<PostTagEntity>();
        public List<LikeEntity> Likes { get; set; } = new List<LikeEntity>();
        public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
        
    }
}
