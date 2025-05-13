using LEC.OnlineCours.Core.DTOs;

namespace LEC.OnlineCours.Services
{
    public interface ICourseCategoryService
    {
        Task<CourseCategoryDto?> GetCourseCategoryByIdAsync(int id);
        Task<List<CourseCategoryDto>> GetAllCourseCategoriesAsync();
    }
}
