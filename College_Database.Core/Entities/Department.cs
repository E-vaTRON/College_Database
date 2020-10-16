using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace College_Database.Core.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Instuctor> Instuctors { get; set; }
    }
}
