using Core.ApplicationModels.Dtos.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductDto
    {        
        public ProductDto()
        {                                    
        }
        public string UniqueCode { get; set; }
        public string RegistryCode { get; set; }
        public string Ncm { get; set; }

        public int? QuantityInStock { get; set; }

        public int? ReorderLevel { get; set; }

        public int? ReorderQuantity { get; set; }

        public decimal? EndCustomerPrice { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SavingPercentage { get; set; }

        public string BarCode { get; set; }

        public string Description { get; set; }

        public string Section { get; set; }

        public decimal MaxDiscountPercentage { get; set; }

        public decimal DiscountValue { get; set; }

        public string Commission { get; set; }

        public decimal ICMS { get; set; }

        public int MinimumStock { get; set; }

        public string MainSupplierName { get; set; }

        public string Name { get; set; }

        public ICollection<ProductSupplierDto> ProductSuppliers { get; set; } = new List<ProductSupplierDto>();

        public ICollection<ProductPriceDto> ProductPrices { get; set; } = new List<ProductPriceDto>();

        public ICollection<ProductStockEntryDto> Stockentries { get; set; } = new List<ProductStockEntryDto>();

        public ICollection<ProductMediaDto> ProductMedias { get; set; } = new List<ProductMediaDto>();

        public ICollection<ProductShelfLifeDto> ShelfLifes { get; set; } = new List<ProductShelfLifeDto>();

        public string ProdutoId { get; set; }
    }
}