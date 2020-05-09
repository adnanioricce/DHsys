using Core.Entities.Catalog;

namespace Core.Entities.Stock
{
    public class ProductStockEntry : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Drug { get; set; }
        public int StockEntryId { get; set; }
        public virtual StockEntry StockEntry { get; set; }
    }
}