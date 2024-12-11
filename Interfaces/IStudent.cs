using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Interfaces
{
    public interface IStudent
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool StudentExists(int id);
    }
}
