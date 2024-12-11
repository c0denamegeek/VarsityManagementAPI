namespace VarsityManagementAPI.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string FacultyAbberviation { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
