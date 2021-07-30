using Repository.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class UserEntity: BaseEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
