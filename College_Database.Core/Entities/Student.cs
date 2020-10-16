using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace College_Database.Core.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public DateTime Birthday { get; set; }

        public string StudentPass { get; set; }

        public User User { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
