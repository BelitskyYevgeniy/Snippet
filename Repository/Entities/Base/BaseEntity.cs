using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
