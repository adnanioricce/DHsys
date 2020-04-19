using System;
using System.Collections.Generic;

namespace Core.Entities.Catalog
{
    public partial class DrugPrice : BaseEntity
    {        
        public int DrugId { get; set; }
        public DateTime? Pricestartdate { get; set; }
        public decimal EndCustomerDrugPrice { get; set; }
        public decimal CostPrice { get; set; }

        public virtual Drug Drug { get; set; }
    }
}
