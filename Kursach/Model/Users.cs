﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Model
{
   public class Users
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string  Password { get; set; }
        public string Email { get; set; }
        public DateTime BirtDay { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
    }
}
