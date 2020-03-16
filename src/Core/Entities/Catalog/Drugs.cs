using System;
using System.Collections.Generic;
using Core.Entities.Stock;

namespace Core.Entities.Catalog
{
    public partial class Drug
    {
        public Drug()
        {
            Druginformation = new HashSet<Druginformation>();
            Drugprices = new HashSet<Drugprices>();
            Stockentries = new HashSet<Stockentries>();
        }

        public int DrugId { get; set; }
        public int? SupplierId { get; set; }
        public string DrugName { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public decimal? DrugCost { get; set; }
        public double? DosageInMg { get; set; }
        public int? QuantityInStock { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQuantity { get; set; }
        public decimal? EndCustomerPrice { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Druginformation> Druginformation { get; set; }
        public virtual ICollection<Catalog.Drugprices> Drugprices { get; set; }
        public virtual ICollection<Stockentries> Stockentries { get; set; }
    }
}
