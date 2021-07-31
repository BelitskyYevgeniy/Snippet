using Snippet.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public List<PostEntity> Posts = new List<PostEntity>();
        public List<LikeEntity> Likes = new List<LikeEntity>();
        public List<CommentEntity> Comments = new List<CommentEntity>();


    }
}
