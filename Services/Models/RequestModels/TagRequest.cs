using System.ComponentModel.DataAnnotations;

namespace Services.Models.RequestModels
{
    public class TagRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
