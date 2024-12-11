using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Interfaces
{
    public interface IFaculty
    {
        IEnumerable<Faculty> GetFaculties();
        Faculty GetFaculty(int id);
        bool CreateFaculty(Faculty faculty);
        bool UpdateModule(Faculty faculty);
        bool FacultyExists(string name);
        bool FacultyExists(int id);
    }
}

