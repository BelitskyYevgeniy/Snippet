using System.ComponentModel.DataAnnotations;

namespace Services.Models.RequestModels
{
    public class CommentRequest
    {
        [Required]
        public int? UserId { get; set; }

        [Required]
        public int? PostId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Message can not be emty")]
        public string Message { get; set; }

        public int? FatherCommentId { get; set; }
    }
}
