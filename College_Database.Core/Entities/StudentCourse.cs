﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace College_Database.Core.Entities
{
    [Table("StudentCourse")]
    public class StudentCourse
    {
        public int StudentCourseID { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
