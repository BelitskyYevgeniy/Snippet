using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Like
    {
       [Key]
        public int Id { get; set; }
        public int postId  { get; set; }
        public int UserId { get; set; }
    }

}
