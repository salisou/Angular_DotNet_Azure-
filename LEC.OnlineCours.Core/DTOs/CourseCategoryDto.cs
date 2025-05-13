namespace LEC.OnlineCours.Core.DTOs
{
    public class CourseCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}