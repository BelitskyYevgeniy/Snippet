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
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime LastUpdateDateTime { get; set; }
        public int? FatherCommentId { get; set; }
    }
}
