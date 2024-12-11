using VarsityManagementAPI.DTOs;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Interfaces
{
    public interface ICourse
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(int id);
        bool CreateCourse(Course course);
        bool UpdateCourse(Course course);
        bool CourseExists(int id);
    }
}
