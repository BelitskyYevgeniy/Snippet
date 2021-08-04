using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }
        
        public int? UserId { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdateDateTime { get; set; } = DateTime.Now;
        public int? FatherCommentId { get; set; }
    }
}
