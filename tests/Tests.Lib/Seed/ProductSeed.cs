using System;
using Core.Entities.Catalog;
using Core.Entities.Media;

namespace Tests.Lib.Seed
{
    public static class ProductSeed
    {
        public static Product BaseCreateProductEntity()
        {
            var drug = new Product
            {
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
                ManufacturerId = 1,                
                Name = "SomeDrugName 30mg 30cp",                
                Classification = "some classification",                
                AbsoluteDosageInMg = 30,
                Dosage = "30mg",                
                ActivePrinciple = "Some Substance",
                PrescriptionNeeded = false,
                DigitalBuleLink = "http://falselink.com/bule000001",                
            };
            drug.AddNewProductMedia(new MediaResource
            {
                SourceUrl = "https://fakeurl.com",
                Type = MediaType.Image
            }, isThumbnail: true);
            return drug;
        }
    }
}