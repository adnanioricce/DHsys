using Core.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class DrugDto : ProductDto
    {
        public DrugDto(ProductDto productDto) : base(productDto)
        {

        }
        public DrugDto()
        {

        }
        public int Id { get; set; }
        public int? BaseDrugId { get; set; }

        public int? SupplierId { get; set; }

        public string PrCdse { get; set; }

        public int? ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public string Name { get; set; }

        public string CommercialName { get; set; }

        public string Classification { get; set; }

        public decimal? DrugCost { get; set; }

        public string Dosage { get; set; }

        public double? AbsoluteDosageInMg { get; set; }

        public string ActivePrinciple { get; set; }

        public string LotNumber { get; set; }

        public bool PrescriptionNeeded { get; set; }

        public bool IsPriceFixed { get; set; }

        public string DigitalBuleLink { get; set; }        
    }
}