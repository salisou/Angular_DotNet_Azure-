using LEC.OnlineCours.Core.DTOs;
using LEC.OnlineCours.Core.Models;
using LEC.OnlineCours.Data.Repository.Interfaces;

namespace LEC.OnlineCours.Services.RepoService
{
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;

        public CourseCategoryService(ICourseCategoryRepository courseCategoryRepository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }

        public async Task<List<CourseCategoryDto>> GetAllCourseCategoriesAsync()
        {
            var data = await _courseCategoryRepository.GetAllCourseCategoriesAsync();
            var modelData = data.Select(c => new CourseCategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return modelData;
        }

        public async Task<CourseCategoryDto?> GetCourseCategoryByIdAsync(int id)
        {
            CourseCategory? data = await _courseCategoryRepository.GetCourseCategoryByIdAsync(id);
            return new CourseCategoryDto
            {
                CategoryId = data?.CategoryId ?? 0,
                CategoryName = data?.CategoryName ?? string.Empty,
                Description = data?.Description
            };
        }
    }
}
