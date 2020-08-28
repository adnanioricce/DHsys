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
            product.Produto = new Core.Entities.Legacy.Produto{
                Prfabr = 14.99d,
                Prcons = 32.99d,                    
                Prbarra = product.BarCode,
                Prcodi = product.UniqueCode,
                UniqueCode = product.UniqueCode,
                Prestq = product.QuantityInStock,
                Prdesc = product.Description,
                Prncms = product.Ncm,
                Id = product.Id  
            };
            return product;
        }
    }
}