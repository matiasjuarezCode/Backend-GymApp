using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGym.Domain.Entities
{
    public class Product : EntityBase
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public bool DiscountStock { get; set; }
        public bool NegativeStock { get; set; }
    }
}
