using System.ComponentModel.DataAnnotations.Schema;

namespace VarsityManagementAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public ICollection<Module> Modules { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
    }
}
