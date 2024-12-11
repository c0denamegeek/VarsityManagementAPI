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
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly IMapper _mapper;

        public StudentController(IStudent student, IMapper mapper)
        {
            _student = student;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudents()
        {
            var students = _mapper.Map<List<StudentDTO>>(_student.GetStudents()); ;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult GetStudent(int studentId)
        {
            if (!_student.StudentExists(studentId))
            {
                return NotFound();
            }

            var student = _mapper.Map<StudentDTO>(_student.GetStudent(studentId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(student);
        }
    }
}
