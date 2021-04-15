using Core.Entities.Catalog;
using Core.Entities.Inventory;
using System;

namespace DAL.Seed.Catalog
{
    public class ProductTemplateSeed : IDataObjectSeed<ProductTemplate>
    {
        public ProductTemplate GetSeedObject()
        {
            var template = new ProductTemplate
            {
                Classification = "Sample Data",
                CommercialName = "Sample Commercial Name",
                ManufacturerName = "Sample Manufacturer Name",
                Name = "Sample product",
                PrescriptionNeeded = false,
                RegistryCode = Guid.NewGuid().ToString(),
                UseRestriction = "No Restriction",
                CategoriesIds = new int[2]
            };
            template.CategoriesIds[0] = 1;
            template.CategoriesIds[1] = 2;
            return template;
        }
    }
}
