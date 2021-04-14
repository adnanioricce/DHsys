using System.Collections.Generic;
using Core.Models.Dtos.Catalog;

namespace Core.Models.Dtos.Stock
{
    public class SupplierDto : BaseEntityDto
    {        
        public int? AddressId { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public AddressDto Address { get; set; }
        

        public ICollection<StockEntryDto> Stockentries { get; set; }
        
    }
}