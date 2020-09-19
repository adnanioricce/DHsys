using System;
using Core.Entities.Catalog;

namespace Tests.Lib.Seed
{
    public class ProductSeed
    {
        public static Product BaseProductEntity()
        {
            var product = new Product{
                Id = 1,
                Ncm = "30024561",
                Description = "SomeDrugName 30mg 30cp",                        
                QuantityInStock = 4,
                ReorderLevel = 0,
                ReorderQuantity = 1,
                CostPrice = 14.99m, 
                EndCustomerPrice = 32.99m,   
                BarCode = Guid.NewGuid().ToString(),
                UniqueCode = "40028922",                
            };                     
            return product;
        }
    }
}