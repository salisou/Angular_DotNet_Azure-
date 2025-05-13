using LEC.OnlineCours.Core.DTOs;
using LEC.OnlineCours.Data.Repository.Interfaces;

namespace LEC.OnlineCours.Services.RepoService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<List<CourseDto>> GetAllCoursesAsync(int? categoryId = null)
        {
            var courses = await _courseRepository.GetAllCourseAsync(categoryId);
            return courses ?? [];
        }

        public async Task<CourseDetailDto> GetCourseDetailAsync(int categoryId)
        {
            CourseDetailDto? course = await _courseRepository.GetCourseByIdAsync(categoryId);
            return course;
        }
    }
}
