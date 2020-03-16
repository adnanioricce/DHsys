using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Billing : BaseEntity
    {        
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsPaid { get; set; }
        public string Beneficiary { get; set; }
    }
}
