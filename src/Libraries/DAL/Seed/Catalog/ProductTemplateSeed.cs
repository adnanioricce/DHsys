using Core.Entities.Catalog;
using Core.Entities.Stock;
using System;

namespace DAL.Seed.Catalog
{
    public class ProductTemplateSeed : IDataObjectSeed<ProductTemplate>
    {
        public ProductTemplate GetSeedObject()
        {
            var template = new ProductTemplate();                        
            template.Classification = "Sample Data";
            template.CommercialName = "Sample Commercial Name";                                                                                        
            template.ManufacturerName = "Sample Manufacturer Name";                        
            template.Name = "Sample product";            
            template.PrescriptionNeeded = false;
            template.RegistryCode = Guid.NewGuid().ToString();
            template.UseRestriction = "No Restriction";
            template.CategoriesIds = new int[2];
            template.CategoriesIds[0] = 1;
            template.CategoriesIds[1] = 2;
            return template;
        }
    }
}
