using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VarsityManagementAPI.DTOs;
using VarsityManagementAPI.Interfaces;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _course;
        private readonly IMapper _mapper;

        public CourseController(ICourse course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetCourses()
        {
            var courses = _mapper.Map<List<CourseDTO>>(_course.GetCourses()); ;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(400)]
        public IActionResult GetCourse(int courseId)
        {
            if (!_course.CourseExists(courseId))
            {
                return NotFound();
            }

            var course = _mapper.Map<CourseDTO>(_course.GetCourse(courseId));

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            return Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateCourse([FromBody]CourseDTO createCourse)
        {
            if (createCourse == null)
            {
                return BadRequest(ModelState);
            }

            var course = _course.GetCourses().Where(c => c.CourseName.Trim()
                            .ToUpper() == createCourse.CourseName
                                .TrimEnd().ToUpper()).FirstOrDefault();
            if (course != null)
            {
                ModelState.AddModelError("", "The course already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseMap = _mapper.Map<Course>(createCourse);

            if (!_course.CreateCourse(courseMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");
        }

        [HttpPut("{courseId}")]
        [ProducesResponseType(204)]
        public IActionResult UpdateCourse(int courseId, [FromBody]CourseDTO updateCourse)
        {
            if (updateCourse == null)
            {
                return BadRequest(ModelState);
            }

            if (courseId != updateCourse.CourseId)
            {
                return BadRequest(ModelState);
            }

            if (!_course.CourseExists(courseId))
            {
                return BadRequest(ModelState);
            }

            var courseMap = _mapper.Map<Course>(updateCourse);

            if (!_course.UpdateCourse(courseMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
