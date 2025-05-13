using LEC.OnlineCours.Core.DTOs;

namespace LEC.OnlineCours.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllCoursesAsync(int? categoryId = null);
        Task<CourseDetailDto> GetCourseDetailAsync(int courseId);
        //Task AddCourseAsync(CourseDetailDto courseDto);
        //Task UpdateCourseAsync(CourseDetailDto courseDto);
        //Task DeleteCourseAsync(int courseId);
        //Task<List<InstructorDto>> GetAllInstructorsAsync();
        //Task<bool> UpdateCourseThumbnail(string courseThumbnailUrl, int courseId);
    }
}
