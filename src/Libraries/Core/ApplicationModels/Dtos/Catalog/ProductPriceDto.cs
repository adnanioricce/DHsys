using System;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductPriceDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public DateTimeOffset? Pricestartdate { get; set; }

        public decimal EndCustomerDrugPrice { get; set; }

        public decimal CostPrice { get; set; }

        public ProductDto Product { get; set; }

        public static ProductPriceDto FromModel(ProductPrice model)
        {
            return new ProductPriceDto()
            {
                ProductId = model.ProductId, 
                Pricestartdate = model.Pricestartdate, 
                EndCustomerDrugPrice = model.EndCustomerDrugPrice, 
                CostPrice = model.CostPrice, 
                Product = ProductDto.FromModel(model.Product), 
            }; 
        }

        public ProductPrice ToModel()
        {
            return new ProductPrice()
            {
                ProductId = ProductId, 
                Pricestartdate = Pricestartdate, 
                EndCustomerDrugPrice = EndCustomerDrugPrice, 
                CostPrice = CostPrice, 
                Product = Product.ToModel(), 
            }; 
        }
    }
}