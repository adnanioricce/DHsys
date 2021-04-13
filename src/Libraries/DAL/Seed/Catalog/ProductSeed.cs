using Core.Entities.Catalog;
using Core.Entities.Stock;
using DAL.Seed.Catalog;
using System;

namespace DAL.Seed
{
    public class ProductSeed : IDataObjectSeed<Product>
    {
        public Product GetSeedObject()
        {
            var product = new Product
            {
                AbsoluteDosageInMg = 1,
                ActivePrinciple = "No Principle",
                BarCode = Guid.NewGuid().ToString("N"),
                //product.BaseproductId
                Classification = "Sample Data",
                CommercialName = "Sample Commercial Name",
                Commission = "0,00",
                //product.CostPrice = 10m;
                CreatedAt = DateTimeOffset.UtcNow,
                Description = "Sample Description",
                DigitalBuleLink = "https://sample.com.br",
                DiscountValue = 0,
                //TODO: Convert the unit measure?
                Dosage = "1",
                //product.EndCustomerPrice = 12;
                ICMS = 18,
                IsPriceFixed = false,
                //TODO:Lot number probably has his own formatting
                LotNumber = Guid.NewGuid().ToString("N"),
                LaboratoryCode = Guid.NewGuid().ToString(),
                LaboratoryName = "Sample Laboratory Name",
                MainSupplierName = "Sample Main Supplier",
                ManufacturerName = "Sample Manufacturer Name",
                MaxDiscountPercentage = 20,
                MinimumStock = 1,
                Name = "Sample product",
                Ncm = "40028922",
                PrescriptionNeeded = false,
                RegistryCode = Guid.NewGuid().ToString(),
                UseRestriction = "No Restriction"
            };
            product.AddNewProductMedia(new Core.Entities.Media.MediaResource
            {
                UniqueCode = Guid.NewGuid().ToString(),
                Type = Core.Entities.Media.MediaType.Image,
                SourceUrl = "https://fakeurl.com"
            });
            product.UpdatePrice(12.00m, 10.00m,DateTimeOffset.UtcNow);
            var supplier = new Supplier
            {
                Cnpj = "1234456567678",
            };
            supplier.Address = new AddressSeed().GetSeedObject();            
            product.AddSupplier(supplier);                     
            product.UniqueCode = Guid.NewGuid().ToString();            
            return product;
        }
    }
}
