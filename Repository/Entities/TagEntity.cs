using Snippet.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class TagEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
       
        public List<PostTagEntity> PostTags { get; set; } = new List<PostTagEntity>();
    }
}
