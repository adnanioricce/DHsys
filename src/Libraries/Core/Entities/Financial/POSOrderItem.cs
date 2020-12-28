using Core.Entities.Catalog;

namespace Core.Entities.Financial
{
    public class POSOrderItem : BaseEntity
    {
        public string ProductUniqueCode { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal CustomerValue { get; set; }
        public decimal CostPrice { get; set; }
        public int POSOrderId { get; set; }
        public virtual POSOrder POSOrder { get; set; }
    }
}