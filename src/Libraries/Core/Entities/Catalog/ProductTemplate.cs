using Core.Entities.Financial;
using System;
using System.Collections.Generic;

namespace Core.Entities.Catalog
{
    public class ProductTemplate : BaseEntity
    {        
        public string Name { get; set; }
        public string CommercialName { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerCountry { get; set; }
        public string OwnerOfRegistry { get; set; }
        public string RegistryCode { get; set; }
        public DateTime RegistryPublicationDate { get; set; }
        public DateTimeOffset DateOfRegistryUpdate { get; set; }
        public string RegistryValidity { get; set; }
        public string MedicalProductModel { get; set; }
        public string Classification { get; set; }
        public RiskClass RiskClass { get; set; }
        public string ActivePrinciple { get; set; }
        public string Concentration { get; set; }
        public string FisicForm { get; set; }
        public string UseRestriction { get; set; }
        public bool PrescriptionNeeded { get; set; }
        public Stripes Stripe { get; set; }
        public bool IsPricedFixed { get; set; }
        public string LaboratoryName { get; set; }
        public decimal EndCustomerPrice { get; set; }
        public decimal CostPrice { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Tax> Taxes { get; set; } = new List<Tax>();
        public Product CreateProduct()
        {
            var product = new Product
            {
                RegistryCode = this.RegistryCode,
                Name = this.Name,
                RiskClass = this.RiskClass,
                CommercialName = this.CommercialName,
                OwnerOfRegistry = this.OwnerOfRegistry,
                ManufacturerName = this.ManufacturerName,
                ManufacturerCountry = this.ManufacturerCountry,
                MedicalProductModel = this.MedicalProductModel,
                RegistryPublicationDate = this.RegistryPublicationDate,
                RegistryValidity = this.RegistryValidity,
                DateOfRegistryUpdate = this.DateOfRegistryUpdate,
                Stripe = this.Stripe,
                LaboratoryName = this.LaboratoryName,
            };
            foreach(var category in Categories)
            {
                product.AddToCategory(category);
            }
            foreach (var tax in Taxes)
            {
                product.AddTax(tax);
            }
            return product;
        }
    }
}