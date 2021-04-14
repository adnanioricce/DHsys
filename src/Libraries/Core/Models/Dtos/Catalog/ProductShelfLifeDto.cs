using System;
using Core.Entities.Catalog;

namespace Core.Models.Dtos.Catalog
{
    public class ProductShelfLifeDto : BaseEntityDto
    {        
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int StockEntryId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public static ProductShelfLifeDto FromModel(ProductShelfLife model)
        {
            return new ProductShelfLifeDto()
            {
                ProductId = model.ProductId, 
                StockEntryId = model.StockEntryId, 
                StartDate = model.StartDate, 
                EndDate = model.EndDate, 
            }; 
        }

        public ProductShelfLife ToModel()
        {
            return new ProductShelfLife()
            {
                ProductId = ProductId, 
                StockEntryId = StockEntryId, 
                StartDate = StartDate, 
                EndDate = EndDate, 
            }; 
        }
    }
}