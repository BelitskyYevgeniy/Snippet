using Services.Models.Base;
using Snippet.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Tag : BaseModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public List<PostEntity> Posts { get; set; } = new List<PostEntity>();
    }
}
