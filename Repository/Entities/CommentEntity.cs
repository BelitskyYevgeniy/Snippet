using Snippet.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class CommentEntity : BaseEntity
    {
        [Required]
        public int PostId { get; set; }
        public PostEntity Post { get; set; }

        public int? UserId { get; set; }
        public UserEntity User { get; set; }
        [Required]
        public string Message { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime LastUpdateDateTime { get; set; }

        public int? ParentCommentId{ get;set;}
        public CommentEntity ParentComment { get;set; }
    }
}
