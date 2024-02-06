using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppsCHOOL.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; } 
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
