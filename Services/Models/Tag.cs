using System;
using System.ComponentModel.DataAnnotations;

namespace Snippet.BLL.Models
{
    public class Tag
    {     
        [Required]
        public string Name { get; set; }
    }
}
