using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VarsityManagementAPI.DTOs;
using VarsityManagementAPI.Interfaces;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFaculty _faculty;
        private readonly IMapper _mapper;
        public FacultyController(IFaculty faculty, IMapper mapper) 
        {
            _faculty = faculty;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Faculty>))]
        public IActionResult GetFaculties()
        {
            var faculties = _mapper.Map<List<FacultyDTO>>(_faculty.GetFaculties()); ;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(faculties);
        }

        [HttpGet("{facultyId}")]
        [ProducesResponseType(200, Type = typeof(Faculty))]
        [ProducesResponseType(400)]
        public IActionResult GetCourse(int facultyId)
        {
            if (!_faculty.FacultyExists(facultyId))
            {
                return NotFound();
            }

            var faculty = _mapper.Map<FacultyDTO>(_faculty.GetFaculty(facultyId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(faculty);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateFaculty([FromBody] FacultyDTO createFaculty)
        {
            if (createFaculty == null)
            {
                return BadRequest(ModelState);
            }

            var faculty = _faculty.GetFaculties().Where(c => c.FacultyName.Trim()
                            .ToUpper() == createFaculty.FacultyName
                                .TrimEnd().ToUpper()).FirstOrDefault();
            if (faculty != null)
            {
                ModelState.AddModelError("", "The course already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facultyMap = _mapper.Map<Faculty>(createFaculty);

            if (!_faculty.CreateFaculty(facultyMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");
        }
    }
}
