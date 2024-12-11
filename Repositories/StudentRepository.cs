using AutoMapper;
using VarsityManagementAPI.Data;
using VarsityManagementAPI.Interfaces;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Repositories
{
    
    public class StudentRepository : IStudent
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public StudentRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public bool StudentExists(int id)
        {
            return _context.Students.Any(s => s.StudentId == id);
        }

        public bool CreateStudent(Student student)
        {
            if (student == null)
            {
                return false;
            }
            _context.Students.Add(student);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return true;
        }
    }
}
