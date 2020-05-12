using System;
using System.Collections.Generic;

namespace Core.Entities.Catalog
{
    public class ProductPrice : BaseEntity
    {        
        public int ProductId { get; set; }
        public DateTimeOffset? Pricestartdate { get; set; }
        public decimal EndCustomerDrugPrice { get; set; }
        public decimal CostPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}
