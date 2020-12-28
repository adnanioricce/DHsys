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
            var product = new Product();
            product.AbsoluteDosageInMg = 1;
            product.ActivePrinciple = "No Principle";
            product.BarCode = Guid.NewGuid().ToString("N");
            //product.BaseproductId
            product.Classification = "Sample Data";
            product.CommercialName = "Sample Commercial Name";
            product.Commission = "0,00";
            //product.CostPrice = 10m;
            product.CreatedAt = DateTimeOffset.UtcNow;
            product.Description = "Sample Description";
            product.DigitalBuleLink = "https://sample.com.br";
            product.DiscountValue = 0;
            //TODO: Convert the unit measure?
            product.Dosage = "1";
            //product.EndCustomerPrice = 12;
            product.ICMS = 18;
            product.IsPriceFixed = false;
            //TODO:Lot number probably has his own formatting
            product.LotNumber = Guid.NewGuid().ToString("N");
            product.LaboratoryCode = Guid.NewGuid().ToString();
            product.LaboratoryName = "Sample Laboratory Name";
            product.MainSupplierName = "Sample Main Supplier";
            product.ManufacturerName = "Sample Manufacturer Name";
            product.MaxDiscountPercentage = 20;
            product.MinimumStock = 1;
            product.Name = "Sample product";
            product.Ncm = "40028922";
            product.PrescriptionNeeded = false;
            product.RegistryCode = Guid.NewGuid().ToString();            
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
