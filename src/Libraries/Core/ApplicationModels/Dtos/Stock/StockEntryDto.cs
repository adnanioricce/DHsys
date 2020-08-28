using System;
using System.Collections.Generic;
using System.Linq;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;
using Core.Entities.Stock;

namespace Core.ApplicationModels.Dtos.Stock
{
    public class StockEntryDto
    {
        public int? SupplierId { get; set; }

        public int? Quantity { get; set; }

        public DateTime? DrugMaturityDate { get; set; }

        public string NfNumber { get; set; }

        public DateTime? NfEmissionDate { get; set; }

        public decimal? Totalcost { get; set; }

        public string LotCode { get; set; }

        public IList<DrugDto> Drugs { get; set; }

        public SupplierDto Supplier { get; set; }

        public static StockEntryDto FromModel(StockEntry model)
        {
            return new StockEntryDto()
            {
                SupplierId = model.SupplierId, 
                Quantity = model.Quantity, 
                DrugMaturityDate = model.DrugMaturityDate, 
                NfNumber = model.NfNumber, 
                NfEmissionDate = model.NfEmissionDate, 
                Totalcost = model.Totalcost, 
                LotCode = model.LotCode, 
                Drugs = model.Drugs.Select(d => DrugDto.FromModel(d)).ToList(), 
                Supplier = SupplierDto.FromModel(model.Supplier), 
            }; 
        }

        public StockEntry ToModel()
        {
            return new StockEntry()
            {
                SupplierId = SupplierId, 
                Quantity = Quantity, 
                DrugMaturityDate = DrugMaturityDate, 
                NfNumber = NfNumber, 
                NfEmissionDate = NfEmissionDate, 
                Totalcost = Totalcost, 
                LotCode = LotCode, 
                Drugs = Drugs.Select(d => d.ToModel()).ToList(), 
                Supplier = Supplier.ToModel(), 
            }; 
        }
    }
}