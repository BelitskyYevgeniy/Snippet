using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Like
    {
       [Key]
        public int Id { get; set; }
        [Required]
        public int postId  { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public Post post { get; set; }
    }

}
