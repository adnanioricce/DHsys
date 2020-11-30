using System;
using System.Collections.Generic;
using Core.ApplicationModels.Dtos.Catalog;

namespace Core.ApplicationModels.Dtos.Stock
{
    public class StockEntryDto : BaseEntityDto
    {                        
        public int? ItemsCount { get { return Items.Count; } }        
        public string NfNumber { get; set; }
        public DateTime? NfEmissionDate { get; set; }
        public decimal? Totalcost { get; set; }
        public IList<ProductStockEntryDto> Items { get; set; } = new List<ProductStockEntryDto>();        
    }
}