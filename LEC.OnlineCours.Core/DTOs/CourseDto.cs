namespace LEC.OnlineCours.Core.DTOs
{
    public class InstructorDto
    {
        public int InstructorId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Bio { get; set; }

        public int UserId { get; set; }
    }
    public class CourseDetailDto : CourseDto
    {
        public List<UserReviewDto>? Reviews { get; set; } = new List<UserReviewDto>();


        public required List<SessionDetailDto> SessionDetails { get; set; }
    }
    public class CourseDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string CourseType { get; set; } = null!;

        public int? SeatsAvailable { get; set; }

        public decimal Duration { get; set; }

        public int CategoryId { get; set; }

        public int InstructorId { get; set; }
        public int InstructorUserId { get; set; }
        public string? Thumbnail { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public CourseCategoryDto? Category { get; set; } = null!;
        public UserRatingDto? UserRating { get; set; } = null!;

    }

    public class UserReviewDto
    {
        public int ReviewId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string? Comments { get; set; }

        public DateTime ReviewDate { get; set; }
    }

    public class SessionDetailDto
    {
        public int SessionId { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? VideoUrl { get; set; }

        public int VideoOrder { get; set; }

    }
    public class UserRatingDto
    {
        public int CourseId { get; set; }

        public decimal AverageRating { get; set; }

        public int TotalRating { get; set; }
    }
}
