using System;
using System.Linq;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class DrugDto
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

        public static DrugDto FromModel(Drug model)
        {
            return new DrugDto()
            {
                BaseDrugId = model.BaseDrugId,                 
                PrCdse = model.PrCdse, 
                ManufacturerId = model.ManufacturerId, 
                ManufacturerName = model.ManufacturerName, 
                CommercialName = model.CommercialName, 
                Classification = model.Classification, 
                Dosage = model.Dosage, 
                AbsoluteDosageInMg = model.AbsoluteDosageInMg, 
                ActivePrinciple = model.ActivePrinciple, 
                LotNumber = model.LotNumber, 
                PrescriptionNeeded = model.PrescriptionNeeded, 
                IsPriceFixed = model.IsPriceFixed, 
                DigitalBuleLink = model.DigitalBuleLink, 
            }; 
        }

        public Drug ToModel()
        {
            return new Drug()
            {
                BaseDrugId = BaseDrugId,                 
                PrCdse = PrCdse, 
                ManufacturerId = ManufacturerId, 
                ManufacturerName = ManufacturerName, 
                CommercialName = CommercialName, 
                Classification = Classification, 
                Dosage = Dosage, 
                AbsoluteDosageInMg = AbsoluteDosageInMg, 
                ActivePrinciple = ActivePrinciple, 
                LotNumber = LotNumber, 
                PrescriptionNeeded = PrescriptionNeeded, 
                IsPriceFixed = IsPriceFixed, 
                DigitalBuleLink = DigitalBuleLink, 
            }; 
        }
    }
}