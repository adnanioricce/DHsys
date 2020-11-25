using System;
using System.Linq;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class DrugDto : ProductDto
    {
        public int? BaseDrugId { get; set; }

        public string PrCdse { get; set; }

        public int? ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public string CommercialName { get; set; }

        public string Classification { get; set; }

        public string Dosage { get; set; }

        public double? AbsoluteDosageInMg { get; set; }

        public string ActivePrinciple { get; set; }

        public string LotNumber { get; set; }

        public bool PrescriptionNeeded { get; set; }

        public bool IsPriceFixed { get; set; }

        public string DigitalBuleLink { get; set; }

        public string LaboratoryCode { get; set; }

        public string LaboratoryName { get; set; }


    }
}