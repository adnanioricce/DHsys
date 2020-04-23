using System;
using System.Collections.Generic;
using Core.Entities.Catalog;

namespace Core.Entities.Stock
{
    public class StockEntry : BaseEntity
    {                
        public int? SupplierId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DrugMaturityDate { get; set; }
        public string NfNumber { get; set; }
        public DateTime? NfEmissionDate { get; set; }
        public decimal? Totalcost { get; set; }
        public string LotCode { get; set; }
        public virtual IList<Drug> Drugs { get; set; } = new List<Drug>();
        public virtual Supplier Supplier { get; set; }
        public void AddDrug(Drug drug)
        {
            if(drug is null) return;

            this.Drugs.Add(drug);
        }
    }
}
