using LEC.OnlineCours.Services;
using Microsoft.AspNetCore.Mvc;

namespace LEC.OnlineCours.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService _courseCategoryService;

        public CourseCategoryController(ICourseCategoryService courseCategoryService)
        {
            _courseCategoryService = courseCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoursesCategory()
        {
            var data = await _courseCategoryService.GetAllCourseCategoriesAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseCategoryById(int id)
        {
            var data = await _courseCategoryService.GetCourseCategoryByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);

        }
    }
}
