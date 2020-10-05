using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductDto
    {
        public ProductDto()
        {

        }
        public ProductDto(ProductDto dto)
        {
            Ncm = dto.Ncm;
            QuantityInStock = dto.QuantityInStock;
            ReorderLevel = dto.ReorderLevel;
            ReorderQuantity = dto.ReorderQuantity;
            EndCustomerPrice = dto.EndCustomerPrice;
            CostPrice = dto.CostPrice;
            SavingPercentage = dto.SavingPercentage;
            BarCode = dto.BarCode;
            Description = dto.Description;
            Section = dto.Section;
            MaxDiscountPercentage = dto.MaxDiscountPercentage;
            DiscountValue = dto.DiscountValue;
            Commission = dto.Commission;
            ICMS = dto.ICMS;
            MinimumStock = dto.MinimumStock;
            MainSupplierName = dto.MainSupplierName;
            ProductSuppliers = dto.ProductSuppliers;
            ProductPrices = dto.ProductPrices;
            Stockentries = dto.Stockentries;
            ShelfLifes = dto.ShelfLifes;                        
        }
        public int Id { get; set; }
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

        public ICollection<ProductSupplierDto> ProductSuppliers { get; set; } = new List<ProductSupplierDto>();

        public ICollection<ProductPriceDto> ProductPrices { get; set; } = new List<ProductPriceDto>();

        public ICollection<ProductStockEntryDto> Stockentries { get; set; } = new List<ProductStockEntryDto>();

        public ICollection<ProductShelfLifeDto> ShelfLifes { get; set; } = new List<ProductShelfLifeDto>();        
                
    }
}