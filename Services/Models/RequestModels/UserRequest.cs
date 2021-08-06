using System.ComponentModel.DataAnnotations;

namespace Services.Models.RequestModels
{
    public class UserRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
