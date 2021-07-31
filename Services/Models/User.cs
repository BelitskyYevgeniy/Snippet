using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.BLL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();


    }
}
