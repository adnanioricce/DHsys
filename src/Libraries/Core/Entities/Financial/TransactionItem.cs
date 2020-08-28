using Core.Entities.Catalog;

namespace Core.Entities.Financial
{
    public class TransactionItem : BaseEntity
    {
        public string DrugUniqueCode { get; set; }
        public virtual Drug Drug { get; set; }
        public int Quantity { get; set; }
        public decimal CustomerValue { get; set; }
        public decimal CostPrice { get; set; }        
    }
}