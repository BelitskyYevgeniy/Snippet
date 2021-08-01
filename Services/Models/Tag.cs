using Services.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Tag : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
