using System.ComponentModel.DataAnnotations;

namespace Services.Models.ResponseModels
{
    public class TagResponse
    {
        [Required]
        public string Name { get; set; }
    }
}
