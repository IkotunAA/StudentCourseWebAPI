using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIBatch20.Services.Interfaces;
using static WebAPIBatch20.Models.CourseModels;

namespace WebAPIBatch20.Controllers
{
    [Authorize]
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public IActionResult AddCourse(CourseRequest request)
        {
            var response = _courseService.Add(request);
            return Ok(response);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateCourse(int id, CourseRequest request)
        {
            var response = _courseService.Edit(id, request);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var response = _courseService.Get(id);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _courseService.GetAllCourses();
            return Ok(response);
        }


    }
}
