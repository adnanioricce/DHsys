using System;

namespace Core.Entities.Catalog
{
    public class ProductPrice : BaseEntity
    {
        protected ProductPrice(int productId, decimal costPrice, decimal endCustomerDrugPrice, DateTimeOffset? pricestartdate)
        {
            Pricestartdate = pricestartdate;
            EndCustomerDrugPrice = endCustomerDrugPrice;
            CostPrice = costPrice;
            ProductId = productId;
        }
        
        public DateTimeOffset? Pricestartdate { get; protected set; } = DateTimeOffset.UtcNow;
        public decimal EndCustomerDrugPrice { get; protected set; }
        public decimal CostPrice { get; protected set; }
        public int ProductId { get; protected set; }
        public virtual Product Product { get; protected set; }
        public virtual decimal CalculatePercentageSaving()
        {
            return ((this.EndCustomerDrugPrice - this.CostPrice) / this.EndCustomerDrugPrice);
        }
        public override string ToString()
        {
            return String.Format("Id:{0},ProductId:{1} \t Customer Price: {2} \t Cost Price: {3}",this.Id,this.ProductId,this.EndCustomerDrugPrice,this.CostPrice);
        }
        public static ProductPrice CreateNewPrice(Product product,decimal costPrice, decimal endCustomerDrugPrice, DateTimeOffset pricestartdate)
        {
            if(costPrice < 0)
            {
                throw new ArgumentException("It's not possible to create a negative cost price");
            }
            else if (endCustomerDrugPrice <= 0)
            {
                throw new ArgumentException("It's not possible to create a non-positive end customer price ");
            }
            bool isStartDateOlderThanActual = pricestartdate.UtcDateTime < DateTimeOffset.UtcNow.UtcDateTime;
            return new ProductPrice(product.Id,costPrice, endCustomerDrugPrice, isStartDateOlderThanActual ? DateTimeOffset.UtcNow : pricestartdate);            
        }
        
    }
}
