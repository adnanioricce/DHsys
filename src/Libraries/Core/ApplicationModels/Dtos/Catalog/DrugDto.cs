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
        

        public static DrugDto FromModel(Drug model)
        {
            return new DrugDto()
            {
                BaseDrugId = model.BaseDrugId, 
                SupplierId = model.SupplierId, 
                PrCdse = model.PrCdse, 
                ManufacturerId = model.ManufacturerId, 
                ManufacturerName = model.ManufacturerName, 
                Name = model.Name, 
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
                Name = Name, 
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
                Ncm = Ncm,
                QuantityInStock = QuantityInStock,
                ReorderLevel = ReorderLevel,
                ReorderQuantity = ReorderQuantity,
                EndCustomerPrice = EndCustomerPrice,
                CostPrice = CostPrice,
                SavingPercentage = SavingPercentage,
                BarCode = BarCode,
                Description = Description,
                Section = Section,
                MaxDiscountPercentage = MaxDiscountPercentage,
                DiscountValue = DiscountValue,
                Commission = Commission,
                ICMS = ICMS,
                MinimumStock = MinimumStock,
                MainSupplierName = MainSupplierName,
                ProductSuppliers = ProductSuppliers.Select(p => p.ToModel()).ToList(),
                ProductPrices = ProductPrices.Select(p => p.ToModel()).ToList(),
                Stockentries = Stockentries.Select(p => p.ToModel()).ToList(),
                ShelfLifes = ShelfLifes.Select(p => p.ToModel()).ToList(),
                //Produto = Produto.ToModel(), 
                ProdutoId = ProdutoId,
            }; 
        }
    }
}