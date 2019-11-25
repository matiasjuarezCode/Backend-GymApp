using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ProjectGym.Domain.Entities
{
    public class Employee : EntityBase
    {
        public int Legacy { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }


    }
}
