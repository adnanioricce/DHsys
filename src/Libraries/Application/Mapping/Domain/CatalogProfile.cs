using Core.ApplicationModels.Dtos.Catalog;
using AutoMapper;
using Core.Entities.Catalog;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Stock;

namespace Application.Mapping.Domain
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<ProductPriceDto, ProductPrice>();
            CreateMap<ProductPrice, ProductPriceDto>();
            CreateMap<ProductShelfLifeDto, ProductShelfLife>();
            CreateMap<ProductShelfLife, ProductShelfLifeDto>();
            CreateMap<ProductStockEntryDto, ProductStockEntry>();
            CreateMap<ProductStockEntry, ProductStockEntryDto>();
            CreateMap<ProductSupplierDto, ProductSupplier>();
            CreateMap<ProductSupplier, ProductSupplierDto>();
            CreateMap<SupplierDto, Supplier>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();            
            CreateMap<DrugInformationDto, DrugInformation>();
            CreateMap<DrugInformation, DrugInformationDto>();
            CreateMap<Drug, DrugDto>();
            CreateMap<DrugDto, Drug>();
        }
    }
}
