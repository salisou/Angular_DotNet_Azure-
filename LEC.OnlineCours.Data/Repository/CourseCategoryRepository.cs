using LEC.OnlineCours.Core.Models;
using LEC.OnlineCours.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LEC.OnlineCours.Data.Repository
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly OnlinecourseContext _context;

        public CourseCategoryRepository(OnlinecourseContext context)
        {
            _context = context;
        }

        public async Task<List<CourseCategory>> GetAllCourseCategoriesAsync()
        {
            var data = await _context.CourseCategories.ToListAsync();
            return data;
        }

        public async Task<CourseCategory?> GetCourseCategoryByIdAsync(int id)
        {
            var data = await _context.CourseCategories.FindAsync(id);
            return data;
        }
    }
}
