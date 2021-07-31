using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Tag
    {     
        [Required]
        public string Name { get; set; }
    }
}
