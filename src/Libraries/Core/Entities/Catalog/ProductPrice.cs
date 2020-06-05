using System;
using System.Collections.Generic;

namespace Core.Entities.Catalog
{
    public class ProductPrice : BaseEntity
    {   
        public ProductPrice()
        {
            
        }     
        public ProductPrice(decimal costPrice,decimal endCustomerDrugPrice)
        {
            EndCustomerDrugPrice = endCustomerDrugPrice;
            CostPrice = costPrice;
        }
        public ProductPrice(decimal costPrice,decimal endCustomerDrugPrice,int productId) : this(costPrice,endCustomerDrugPrice)
        {
            ProductId = productId;
        }
        public int ProductId { get; set; }
        public DateTimeOffset? Pricestartdate { get; set; } = DateTimeOffset.UtcNow;
        public decimal EndCustomerDrugPrice { get; set; }
        public decimal CostPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal CalculatePercentageSaving()
        {
            return ((this.EndCustomerDrugPrice - this.CostPrice) / this.EndCustomerDrugPrice);
        }
    }
}
