using Core.ApplicationModels.Dtos;
using Core.ApplicationModels.Dtos.Catalog;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductDto : BaseEntityDto
    {
        public int? BaseProductId { get; set; }

        public int? ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public string ManufacturerCountry { get; set; }

        public RiskClass RiskClass { get; set; }

        public string Name { get; set; }

        public string CommercialName { get; set; }

        public string Classification { get; set; }

        public float Concentration { get; set; }

        public string FisicForm { get; set; }

        public string Dosage { get; set; }

        public double? AbsoluteDosageInMg { get; set; }

        public string ActivePrinciple { get; set; }

        public string LotNumber { get; set; }

        public bool PrescriptionNeeded { get; set; }

        public string UseRestriction { get; set; }

        public bool IsPriceFixed { get; set; }

        public string DigitalBuleLink { get; set; }

        public string LaboratoryCode { get; set; }

        public string LaboratoryName { get; set; }

        public string Ncm { get; set; }

        public int QuantityInStock { get; set; }

        public DateTimeOffset? LastStockEntry { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }

        public decimal EndCustomerPrice { get; set; }

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

        public string OwnerOfRegistry { get; set; }

        public string RegistryCode { get; set; }

        public DateTime RegistryPublicationDate { get; set; }

        public DateTimeOffset DateOfRegistryUpdate { get; set; }

        public string RegistryValidity { get; set; }

        public string MedicalProductModel { get; set; }

        public Stripes Stripe { get; set; }

        public ICollection<ProductSupplierDto> ProductSuppliers { get; set; } = new List<ProductSupplierDto>();

        public ICollection<ProductPriceDto> ProductPrices { get; set; } = new List<ProductPriceDto>();

        public ICollection<ProductStockEntryDto> Stockentries { get; set; } = new List<ProductStockEntryDto>();

        public ICollection<ProductMediaDto> ProductMedias { get; set; } = new List<ProductMediaDto>();

        public ICollection<ProductShelfLifeDto> ShelfLifes { get; set; } = new List<ProductShelfLifeDto>();

        public ICollection<ProductCategoryDto> Categories { get; set; } = new List<ProductCategoryDto>();

        public ICollection<StockChangeDto> StockChanges { get; set; } = new List<StockChangeDto>();

        public ICollection<ProductTaxDto> ProductTaxes { get; set; } = new List<ProductTaxDto>();
    }
}