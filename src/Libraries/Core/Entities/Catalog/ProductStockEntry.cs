using Core.Entities.Stock;
using System;

namespace Core.Entities.Catalog
{
    public class ProductStockEntry : BaseEntity
    {
        public ProductStockEntry(){}        
        public int ProductId { get; set; }
        public virtual Drug Product { get; set; }
        public int StockEntryId { get; set; }
        public virtual StockEntry StockEntry { get; set; }
        public DateTime? ProductMaturityDate { get; set; }
        public int Quantity { get; set; }
        public string LotCode { get; set; }

    }
}