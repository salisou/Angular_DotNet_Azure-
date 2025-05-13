using LEC.OnlineCours.Core.Models;

namespace LEC.OnlineCours.Data.Repository.Interfaces
{
    public interface ICourseCategoryRepository
    {
        Task<CourseCategory?> GetCourseCategoryByIdAsync(int id);
        Task<List<CourseCategory>> GetAllCourseCategoriesAsync();
    }
}
