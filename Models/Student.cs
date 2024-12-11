namespace VarsityManagementAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentEmail { get; set; }
        public int StudentNumber { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
    }
}
