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

        public int? BaseDrugId { get; set; }

        public int? SupplierId { get; set; }

        public string PrCdse { get; set; }

        public int? ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public string DrugName { get; set; }

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

        public ICollection<DrugInformationDto> Druginformation { get; set; } = new List<DrugInformationDto>();

        public static DrugDto FromModel(Drug model)
        {
            return new DrugDto()
            {
                BaseDrugId = model.BaseDrugId, 
                SupplierId = model.SupplierId, 
                PrCdse = model.PrCdse, 
                ManufacturerId = model.ManufacturerId, 
                ManufacturerName = model.ManufacturerName, 
                DrugName = model.DrugName, 
                CommercialName = model.CommercialName, 
                Classification = model.Classification, 
                DrugCost = model.DrugCost, 
                Dosage = model.Dosage, 
                AbsoluteDosageInMg = model.AbsoluteDosageInMg, 
                ActivePrinciple = model.ActivePrinciple, 
                LotNumber = model.LotNumber, 
                PrescriptionNeeded = model.PrescriptionNeeded, 
                IsPriceFixed = model.IsPriceFixed, 
                DigitalBuleLink = model.DigitalBuleLink, 
                Druginformation = model.Druginformation.Select(d => DrugInformationDto.FromModel(d)).ToList(), 
            }; 
        }

        public Drug ToModel()
        {            
            return new Drug()
            {
                BaseDrugId = BaseDrugId, 
                SupplierId = SupplierId, 
                PrCdse = PrCdse, 
                ManufacturerId = ManufacturerId, 
                ManufacturerName = ManufacturerName, 
                DrugName = DrugName, 
                CommercialName = CommercialName, 
                Classification = Classification, 
                DrugCost = DrugCost, 
                Dosage = Dosage, 
                AbsoluteDosageInMg = AbsoluteDosageInMg, 
                ActivePrinciple = ActivePrinciple, 
                LotNumber = LotNumber, 
                PrescriptionNeeded = PrescriptionNeeded, 
                IsPriceFixed = IsPriceFixed, 
                DigitalBuleLink = DigitalBuleLink, 
                Druginformation = Druginformation.Select(d => d.ToModel()).ToList(), 
            }; 
        }
    }
}