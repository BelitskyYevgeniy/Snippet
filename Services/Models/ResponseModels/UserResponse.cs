using System.ComponentModel.DataAnnotations;

namespace Services.Models.ResponseModels
{
    public class UserResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
