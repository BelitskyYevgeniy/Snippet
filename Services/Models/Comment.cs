using System;
using System.ComponentModel.DataAnnotations;

namespace Snippet.BLL.Models
{
    public class Comment
    {
       
        public Guid Id { get; set; }
     
        public Post Post { get; set; }
            
        public User User { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
