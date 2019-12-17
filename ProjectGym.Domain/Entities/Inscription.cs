using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.Entities
{
    public class Inscription : EntityBase
    {
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public long PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public DateTime InscriptionDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

    }
}
