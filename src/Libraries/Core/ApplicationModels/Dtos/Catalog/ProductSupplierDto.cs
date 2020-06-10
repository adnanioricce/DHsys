using System;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductSupplierDto
    {
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int SupplierId { get; set; }

        public SupplierDto Supplier { get; set; }

        public static ProductSupplierDto FromModel(ProductSupplier model)
        {
            return new ProductSupplierDto()
            {
                ProductId = model.ProductId, 
                Product = ProductDto.FromModel(model.Product), 
                SupplierId = model.SupplierId, 
                Supplier = SupplierDto.FromModel(model.Supplier), 
            }; 
        }

        public ProductSupplier ToModel()
        {
            return new ProductSupplier()
            {
                ProductId = ProductId, 
                Product = Product.ToModel(), 
                SupplierId = SupplierId, 
                Supplier = Supplier.ToModel(), 
            }; 
        }
    }
}