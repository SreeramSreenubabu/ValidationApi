using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ValidationService _validationService;

        public CourseController()
        {
            _validationService = new ValidationService();
        }

        [HttpPost]
        public IActionResult ValidateCourse([FromBody] Course course)
        {
            try
            {
                _validationService.ValidateRequestData(course);
                return Ok("Course is valid.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Validation error: {ex.Message}");
            }
        }

        [HttpPost("validateCourse2")]
        public IActionResult ValidateCourse2([FromBody] Course2 course2)
        {
            try
            {
                _validationService.ValidateRequestData(course2);
                return Ok("Course2 is valid.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Validation error: {ex.Message}");
            }
        }

        [HttpPost("validateCourse3")]
        public IActionResult ValidateCourse3([FromBody] Course3 course3)
        {
            try
            {
                _validationService.ValidateRequestData(course3);
                return Ok("Course2 is valid.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Validation error: {ex.Message}");
            }
        }
    }
}
