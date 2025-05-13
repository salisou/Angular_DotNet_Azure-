using LEC.OnlineCours.Core.DTOs;

namespace LEC.OnlineCours.Data.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>?> GetAllCourseAsync(int? categoryId = null);
        Task<CourseDetailDto> GetCourseByIdAsync(int categoryId);
    }
}
