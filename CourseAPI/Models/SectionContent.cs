
namespace CourseAPI.Models
{
    public enum ContentType
    {
        Text,
        Image,
        Video
    }
    public class SectionContent
    {
        public int Id { get; set; }

        public ContentType Type { get; set; }

        public string Data { get; set; } = "";

        public int Order { get; set; }

        public int CourseSectionId { get; set; }
        public CourseSection CourseSection { get; set; } = null!;
    }
}
