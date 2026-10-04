using System.ComponentModel.DataAnnotations;

namespace CourseAPI.Models
{
    public class CourseUpdateRequest
    {
        [StringLength(100, MinimumLength = 2)]
        public string? Title { get; set; }
        [StringLength(1000, MinimumLength = 2)]

        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Price { get; set; }
    }
}
