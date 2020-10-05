using System;
using System.Collections.Generic;
using System.Linq;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Stock;

namespace Core.ApplicationModels.Dtos.Stock
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public int? AddressId { get; set; }

        public string SupplierName { get; set; }

        public string Cnpj { get; set; }

        public AddressDto Address { get; set; }

        public ICollection<ProductSupplierDto> Products { get; set; }

        public ICollection<StockEntryDto> Stockentries { get; set; }
        
    }
}