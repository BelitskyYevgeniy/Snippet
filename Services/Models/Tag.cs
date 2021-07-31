using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Tag
    {
        [Required]
        public int Id;
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
