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

        public static SupplierDto FromModel(Supplier model)
        {
            return new SupplierDto()
            {
                AddressId = model.AddressId, 
                SupplierName = model.Name, 
                Cnpj = model.Cnpj, 
                Address = AddressDto.FromModel(model.Address), 
                Products = model.Products.Select(p => ProductSupplierDto.FromModel(p)).ToList(), 
                Stockentries = model.Stockentries.Select(st => StockEntryDto.FromModel(st)).ToList()
            }; 
        }

        public Supplier ToModel()
        {
            return new Supplier()
            {
                AddressId = AddressId, 
                Name = SupplierName, 
                Cnpj = Cnpj, 
                Address = Address.ToModel(), 
                Products = Products.Select(p => p.ToModel()).ToList(), 
                Stockentries = Stockentries.Select(st => st.ToModel()).ToList(), 
            }; 
        }
    }
}