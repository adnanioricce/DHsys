using System;
using Core.Entities.Catalog;
using Core.Entities.Media;

namespace Tests.Lib.Seed
{
    public static class DrugSeed
    {
        public static Drug BaseCreateDrugEntity()
        {
            var drug = new Drug
            {
                ManufacturerId = 1,
                Ncm = "30024561",
                Name = "SomeDrugName 30mg 30cp",
                Description = "no description",
                Classification = "some classification",
                DrugCost = 14.99m,
                AbsoluteDosageInMg = 30,
                Dosage = "30mg",
                QuantityInStock = 4,
                ReorderLevel = 0,
                ReorderQuantity = 1,
                EndCustomerPrice = 32.99m,
                ActivePrinciple = "Some Substance",
                PrescriptionNeeded = false,
                DigitalBuleLink = "http://falselink.com/bule000001",
                BarCode = Guid.NewGuid().ToString(),
                UniqueCode = "40028922",
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