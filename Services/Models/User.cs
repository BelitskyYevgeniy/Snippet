using Services.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class User:BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        public List<Post> Posts { get; set; } = new List<Post>();


    }
}
