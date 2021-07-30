using Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class LanguageEntity: BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
