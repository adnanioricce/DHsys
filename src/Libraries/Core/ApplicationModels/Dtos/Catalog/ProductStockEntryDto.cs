using System;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductStockEntryDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int StockEntryId { get; set; }

        public StockEntryDto StockEntry { get; set; }

        public static ProductStockEntryDto FromModel(ProductStockEntry model)
        {
            return new ProductStockEntryDto()
            {
                ProductId = model.ProductId, 
                Product = ProductDto.FromModel(model.Product), 
                StockEntryId = model.StockEntryId, 
                StockEntry = StockEntryDto.FromModel(model.StockEntry), 
            }; 
        }

        public ProductStockEntry ToModel()
        {
            return new ProductStockEntry()
            {
                ProductId = ProductId, 
                Product = Product.ToModel(), 
                StockEntryId = StockEntryId, 
                StockEntry = StockEntry.ToModel(), 
            }; 
        }
    }
}