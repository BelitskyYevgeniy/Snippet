using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
