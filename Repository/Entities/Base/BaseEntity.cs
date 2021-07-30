using System.ComponentModel.DataAnnotations;

namespace Repository.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public ulong Id { get; set; } 
    }
}
