namespace CourseAPI.Models
{
    public class CourseSection
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public int Order { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;
        public List<SectionContent> Contents { get; set; } = [];
    }
}
