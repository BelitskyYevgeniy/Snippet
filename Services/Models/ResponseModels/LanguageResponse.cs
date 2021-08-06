using System.ComponentModel.DataAnnotations;

namespace Services.Models.ResponseModels
{
    public class LanguageResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
