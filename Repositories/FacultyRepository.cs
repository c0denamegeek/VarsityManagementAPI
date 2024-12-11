using AutoMapper;
using VarsityManagementAPI.Data;
using VarsityManagementAPI.Interfaces;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Repositories
{
    public class FacultyRepository : IFaculty
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FacultyRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateFaculty(Faculty faculty)
        {
            if (faculty == null)
            {
                return false;
            }
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
            return true;
        }

        public bool FacultyExists(string name)
        {
            throw new NotImplementedException();
        }

        public bool FacultyExists(int id)
        {
            return _context.Faculties.Any(c => c.FacultyId == id);
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            return _context.Faculties.ToList();
        }

        public Faculty GetFaculty(int id)
        {
            return _context.Faculties.Where(c => c.FacultyId == id).FirstOrDefault();
        }

        public bool UpdateModule(Faculty faculty)
        {
            throw new NotImplementedException();
        }
    }
}
