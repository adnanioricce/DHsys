using Core.Entities.Catalog;
using Core.Entities.Stock;
using DAL.Seed.Catalog;
using System;

namespace DAL.Seed
{
    public class DrugSeed : IDataObjectSeed<Drug>
    {
        public Drug GetSeedObject()
        {
            var drug = new Drug();
            drug.AbsoluteDosageInMg = 1;
            drug.ActivePrinciple = "No Principle";
            drug.BarCode = Guid.NewGuid().ToString("N");
            //drug.BaseDrugId
            drug.Classification = "Sample Data";
            drug.CommercialName = "Sample Commercial Name";
            drug.Commission = "0,00";
            drug.CostPrice = 10;
            drug.CreatedAt = DateTimeOffset.UtcNow;
            drug.Description = "Sample Description";
            drug.DigitalBuleLink = "https://sample.com.br";
            drug.DiscountValue = 0;
            //TODO: Convert the unit measure?
            drug.Dosage = "1";
            drug.EndCustomerPrice = 12;
            drug.ICMS = 18;
            drug.IsPriceFixed = false;
            //TODO:Lot number probably has his own formatting
            drug.LotNumber = Guid.NewGuid().ToString("N");
            drug.LaboratoryCode = Guid.NewGuid().ToString();
            drug.LaboratoryName = "Sample Laboratory Name";
            drug.MainSupplierName = "Sample Main Supplier";
            drug.ManufacturerName = "Sample Manufacturer Name";
            drug.MaxDiscountPercentage = 20;
            drug.MinimumStock = 1;
            drug.Name = "Sample Drug";
            drug.Ncm = "40028922";
            drug.PrescriptionNeeded = false;
            drug.RegistryCode = Guid.NewGuid().ToString();            
            drug.AddNewProductMedia(new Core.Entities.Media.MediaResource
            {
                UniqueCode = Guid.NewGuid().ToString(),
                Type = Core.Entities.Media.MediaType.Image,
                SourceUrl = "https://fakeurl.com"
            });
            drug.UpdatePrice(12.00m, 10.00m);
            var supplier = new Supplier
            {
                Cnpj = "1234456567678",
            };
            supplier.Address = new AddressSeed().GetSeedObject();            
            drug.AddSupplier(supplier);
            var category = new CategorySeed().GetSeedObject();
            drug.Categories.Add(new ProductCategory
            {
                Category = category,
                Product = drug
            });
            drug.QuantityInStock = 10;            
            drug.UniqueCode = Guid.NewGuid().ToString();
            return drug;
        }
    }
}
