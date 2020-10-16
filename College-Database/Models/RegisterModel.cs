﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_Database.Models
{
    public class RegisterModel
    {
        public int AuthorID { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}
