using System;
using System.ComponentModel.DataAnnotations;

namespace Snippet.BLL.Models
{
    public class Language
    {     
        [Required]
        public string Name { get; set; }
    }
}

