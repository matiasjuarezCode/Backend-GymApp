using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.Entities
{
    public class Customer : EntityBase
    {
        public int MembershipNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateTime DateAdmission { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
