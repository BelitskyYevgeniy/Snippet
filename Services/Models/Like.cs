using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Like
    {
       [Key]
        public int Id { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }

}
