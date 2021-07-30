using Snippet.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class LanguageEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
