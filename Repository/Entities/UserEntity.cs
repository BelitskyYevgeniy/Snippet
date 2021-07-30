using Snippet.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
