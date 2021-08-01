using Services.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Language:BaseModel
    {     
        [Required]
        public string Name { get; set; }
    }
}

