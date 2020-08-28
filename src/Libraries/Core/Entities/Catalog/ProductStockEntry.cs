using Core.Entities.Stock;

namespace Core.Entities.Catalog
{
    public class ProductStockEntry : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int StockEntryId { get; set; }
        public virtual StockEntry StockEntry { get; set; }
    }
}