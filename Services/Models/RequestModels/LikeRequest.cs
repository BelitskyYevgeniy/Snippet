using System.ComponentModel.DataAnnotations;

namespace Services.Models.RequestModels
{
    public class LikeRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}
