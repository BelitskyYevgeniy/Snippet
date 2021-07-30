using Repository.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class TagEntity: BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
