using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;


        [MaxLength(50)]
        public string? Description { get; set; } = string.Empty;
    }
}
