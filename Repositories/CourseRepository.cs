using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VarsityManagementAPI.Data;
using VarsityManagementAPI.DTOs;
using VarsityManagementAPI.Interfaces;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Repositories
{
    public class CourseRepository : ICourse
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CourseExists(int id)
        {
            return _context.Courses.Any( c => c.CourseId == id);
        }     

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.Where(c => c.CourseId == id).FirstOrDefault();
        }

        public bool CreateCourse(Course course)
        {
            if (course == null)
            {
                return false;
            }
            _context.Courses.Add(course);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return true;
        }
    }
}
