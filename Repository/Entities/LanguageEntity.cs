using Snippet.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class LanguageEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public List<PostEntity> Posts { get; set; } = new List<PostEntity>();
    }
}
