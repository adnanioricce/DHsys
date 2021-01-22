using System;
using System.Linq;
using Core.Entities.Catalog;
using System.Collections.Generic;
namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductTemplateDto : BaseEntityDto
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

        public ICollection<ProductCategory> Categories { get; set; }

        public ICollection<ProductTax> Taxes { get; set; }
    }
}