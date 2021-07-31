using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Language
    {     
        [Required]
        public string Name { get; set; }
    }
}

