using Services.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Like:BaseModel
    {
        [Required]
        public int postId  { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public Post post { get; set; }
    }

}
