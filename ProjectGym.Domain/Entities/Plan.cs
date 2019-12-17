using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.Entities
{
    public class Plan : EntityBase
    {
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inscription> Inscriptions { get; set; }

    }
}
