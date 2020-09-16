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
            ProdutoId = dto.ProdutoId;
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

        public string ProdutoId { get; set; }

        public static ProductDto FromModel(Product model)
        {
            return new ProductDto()
            {
                Ncm = model.Ncm, 
                QuantityInStock = model.QuantityInStock, 
                ReorderLevel = model.ReorderLevel, 
                ReorderQuantity = model.ReorderQuantity, 
                EndCustomerPrice = model.EndCustomerPrice, 
                CostPrice = model.CostPrice, 
                SavingPercentage = model.SavingPercentage, 
                BarCode = model.BarCode, 
                Description = model.Description, 
                Section = model.Section, 
                MaxDiscountPercentage = model.MaxDiscountPercentage, 
                DiscountValue = model.DiscountValue, 
                Commission = model.Commission, 
                ICMS = model.ICMS, 
                MinimumStock = model.MinimumStock, 
                MainSupplierName = model.MainSupplierName, 
                ProductSuppliers = model.ProductSuppliers.Select(p => ProductSupplierDto.FromModel(p)).ToList(), 
                ProductPrices = model.ProductPrices.Select(p => ProductPriceDto.FromModel(p)).ToList(), 
                Stockentries = model.Stockentries.Select(p => ProductStockEntryDto.FromModel(p)).ToList(), 
                ShelfLifes = model.ShelfLifes.Select(p => ProductShelfLifeDto.FromModel(p)).ToList(), 
                //Produto = ProdutoDto.FromModel(model.Produto), 
                ProdutoId = model.ProdutoId, 
            }; 
        }

        public Product ToModel()
        {
            return new Product()
            {
                Ncm = Ncm, 
                QuantityInStock = QuantityInStock, 
                ReorderLevel = ReorderLevel, 
                ReorderQuantity = ReorderQuantity, 
                EndCustomerPrice = EndCustomerPrice, 
                CostPrice = CostPrice, 
                SavingPercentage = SavingPercentage, 
                BarCode = BarCode, 
                Description = Description, 
                Section = Section, 
                MaxDiscountPercentage = MaxDiscountPercentage, 
                DiscountValue = DiscountValue, 
                Commission = Commission, 
                ICMS = ICMS, 
                MinimumStock = MinimumStock, 
                MainSupplierName = MainSupplierName, 
                ProductSuppliers = ProductSuppliers.Select(p => p.ToModel()).ToList(), 
                ProductPrices = ProductPrices.Select(p => p.ToModel()).ToList(), 
                Stockentries = Stockentries.Select(p => p.ToModel()).ToList(), 
                ShelfLifes = ShelfLifes.Select(p => p.ToModel()).ToList(), 
                //Produto = Produto.ToModel(), 
                ProdutoId = ProdutoId, 
            }; 
        }
    }
}