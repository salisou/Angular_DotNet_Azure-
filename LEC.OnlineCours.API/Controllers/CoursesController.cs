using LEC.OnlineCours.Core.DTOs;
using LEC.OnlineCours.Services;
using Microsoft.AspNetCore.Mvc;

namespace LEC.OnlineCours.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetAllCoursesAsync()
        {
            var data = await _courseService.GetAllCoursesAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<List<CourseDto>>> GetCourseByCategoryIdAsync([FromRoute] int categoryId)
        {
            List<CourseDto> data = await _courseService.GetAllCoursesAsync(categoryId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("Detail/{courseId}")]
        public async Task<ActionResult<CourseDto>> GetCourseDetailAsync([FromRoute] int courseId)
        {
            CourseDetailDto data = await _courseService.GetCourseDetailAsync(courseId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
