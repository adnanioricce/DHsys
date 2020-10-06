using System;
using System.Collections.Generic;
using System.Linq;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;
using Core.Entities.Stock;

namespace Core.ApplicationModels.Dtos.Stock
{
    public class StockEntryDto
    {        
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public int? ItemsCount { get { return Items.Count; } }
        public DateTime? DrugMaturityDate { get; set; }
        public string NfNumber { get; set; }

        public DateTime? NfEmissionDate { get; set; }

        public decimal? Totalcost { get; set; }

        public IList<ProductStockEntryDto> Items { get; set; } = new List<ProductStockEntryDto>();

        public SupplierDto Supplier { get; set; }        
    }
}