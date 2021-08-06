using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models.ResponseModels
{
    public class CommentResponse
    {
        [Required]
        public int Id { get; set; }

        public UserResponse User { get; set; } = default;

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime LastUpdateDateTime { get; set; }

        public int? FatherCommentId { get; set; }

    }
}
