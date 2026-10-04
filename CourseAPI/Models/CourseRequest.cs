using System.ComponentModel.DataAnnotations;

namespace CourseAPI.Models
{
    public class CourseRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }
        public string ImageUrl { get; set; } = "";
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public CourseRequest(string title, string imageUrl, decimal price, string description)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
        }
    }
}
