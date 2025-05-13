using LEC.OnlineCours.Core.DTOs;
using LEC.OnlineCours.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LEC.OnlineCours.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OnlinecourseContext _context;

        public CourseRepository(OnlinecourseContext context)
        {
            _context = context;
        }

        public async Task<List<CourseDto>> GetAllCourseAsync(int? categoryId = null)
        {
            var query = _context.Courses
                .Include(c => c.Category)
                //.Include(c => c.Reviews)
                //.Include(c => c.SessionDetails)
                .AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(c => c.CategoryId == categoryId.Value);

            var courses = await query
                .Select(c => new CourseDto()
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    CourseType = c.CourseType,
                    SeatsAvailable = c.SeatsAvailable,
                    Duration = c.Duration,
                    CategoryId = c.CategoryId,
                    InstructorId = c.InstructorId,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Category = new CourseCategoryDto()
                    {
                        CategoryId = c.Category.CategoryId,
                        CategoryName = c.Category.CategoryName,
                        Description = c.Category.Description
                    },
                    UserRating = new UserRatingDto
                    {
                        CourseId = c.CourseId,
                        AverageRating = c.Reviews.Any() ? Convert.ToDecimal(c.Reviews.Sum(r => r.Rating)) / c.Reviews.Count() : 0,
                        TotalRating = c.Reviews.Count(),
                    }
                })
                .ToListAsync();

            return courses;
        }

        public Task<CourseDetailDto> GetCourseByIdAsync(int courseId)
        {
            var course = _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Reviews)
                .Include(c => c.SessionDetails)
                .Where(c => c.CourseId == courseId)
                .Select(c => new CourseDetailDto()
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    CourseType = c.CourseType,
                    SeatsAvailable = c.SeatsAvailable,
                    Duration = c.Duration,
                    CategoryId = c.CategoryId,
                    InstructorId = c.InstructorId,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Category = new CourseCategoryDto()
                    {
                        CategoryId = c.Category.CategoryId,
                        CategoryName = c.Category.CategoryName,
                        Description = c.Category.Description
                    },
                    Reviews = c.Reviews.Select(r => new UserReviewDto
                    {
                        CourseId = r.CourseId,
                        UserName = r.User.DisplayName,
                        Rating = r.Rating,
                        ReviewDate = r.ReviewDate
                    }).OrderByDescending(o => o.Rating).Take(10).ToList(),
                    SessionDetails = c.SessionDetails.Select(s => new SessionDetailDto
                    {
                        SessionId = s.SessionId,
                        CourseId = s.CourseId,
                        Title = s.Title,
                        Description = s.Description,
                        VideoOrder = s.VideoOrder,
                        VideoUrl = s.VideoUrl
                    }).OrderBy(o => o.VideoOrder).ToList(),
                    UserRating = new UserRatingDto
                    {
                        CourseId = c.CourseId,
                        AverageRating = c.Reviews.Any() ? Convert.ToDecimal(c.Reviews.Sum(r => r.Rating)) / c.Reviews.Count() : 0,
                        TotalRating = c.Reviews.Count(),
                    }
                }).FirstOrDefault();
            return course == null ? Task.FromResult<CourseDetailDto>(null!) : Task.FromResult(course);
        }
    }
}
