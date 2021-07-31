using Snippet.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippet.Data.Entities
{
    public class LikeEntity: BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        public int PostId { get; set; }
        public PostEntity Post{ get; set; }

    }
}
