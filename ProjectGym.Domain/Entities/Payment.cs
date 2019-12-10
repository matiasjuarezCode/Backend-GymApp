using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.Entities
{
    public class Payment : EntityBase
    {
        public long InscriptionId { get; set; }
        public virtual Inscription Inscription { get; set; }

        public decimal Money { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
