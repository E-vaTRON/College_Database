using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace College_Database.Core.Entities
{
    [Table("Intructor")]
    public class Instuctor
    {
        [Key]
        public int IntructorID { get; set; }

        public string IntructorName { get; set; }

        public int CMND { get; set; }

        public int Age { get; set; }

        public bool Head { get; set; }

        public ICollection<Course> Courses { get; set; }

        public Department Department { get; set; }
    }
}
