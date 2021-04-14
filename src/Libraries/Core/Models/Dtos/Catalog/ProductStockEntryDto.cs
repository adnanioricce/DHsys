using System;
using Core.Models.Dtos.Stock;
using Core.Entities.Catalog;

namespace Core.Models.Dtos.Catalog
{
    public class ProductStockEntryDto : BaseEntityDto
    {        
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int StockEntryId { get; set; }
        public StockEntryDto StockEntry { get; set; }
        public DateTime? ProductMaturityDate { get; set; }
        public int Quantity { get; set; }
        public string LotCode { get; set; }

    }
}