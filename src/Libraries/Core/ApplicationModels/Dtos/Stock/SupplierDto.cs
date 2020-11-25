using System.Collections.Generic;
using Core.ApplicationModels.Dtos.Catalog;

namespace Core.ApplicationModels.Dtos.Stock
{
    public class SupplierDto : BaseEntityDto
    {        
        public int? AddressId { get; set; }

        public string SupplierName { get; set; }

        public string Cnpj { get; set; }

        public AddressDto Address { get; set; }

        public ICollection<ProductSupplierDto> Products { get; set; }

        public ICollection<StockEntryDto> Stockentries { get; set; }
        
    }
}