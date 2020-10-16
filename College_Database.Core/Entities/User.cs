using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace College_Database.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTime DateCreated { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
