using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace College_Database.Core.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Required]
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public string CourseRoom { get; set; }

        public Department Department { get; set; }

        public Instuctor Intructor { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
