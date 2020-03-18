using System;
using System.Collections.Generic;
using Core.Entities.Catalog;

namespace Core.Entities.Stock
{
    public partial class Stockentries
    {
        public int StockId { get; set; }
        public int? DrugId { get; set; }
        public int? SupplierId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string NfNumber { get; set; }
        public DateTime? NfEmissionDate { get; set; }
        public decimal? Totalcost { get; set; }
        public string LotCode { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
