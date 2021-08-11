using System.ComponentModel.DataAnnotations;

namespace Services.Models.RequestModels
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string AuthId { get; set; } = string.Empty;
    }
}
