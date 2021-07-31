using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int postId { get; set; }
        [Required] 
        public Post Post { get; set; }
        [Required]   
        public User User { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
