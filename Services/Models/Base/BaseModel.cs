using System.ComponentModel.DataAnnotations;

namespace Services.Models.Base
{
    public class BaseModel
    {
       [Key]
       public int Id { get; set; }
       
    }
}
