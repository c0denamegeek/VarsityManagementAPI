using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarsityManagementAPI.Models
{
    public class CourseStudent
    {

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]

        public int CourseId { get; set;}
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
