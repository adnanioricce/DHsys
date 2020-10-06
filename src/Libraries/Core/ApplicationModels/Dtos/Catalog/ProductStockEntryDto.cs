using System;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductStockEntryDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public DrugDto Product { get; set; }

        public int StockEntryId { get; set; }

        public StockEntryDto StockEntry { get; set; }
        public DateTime? ProductMaturityDate { get; set; }
        public int Quantity { get; set; }
        public string LotCode { get; set; }

    }
}