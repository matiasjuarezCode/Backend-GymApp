using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int MembershipNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateTime DateAdmission { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
