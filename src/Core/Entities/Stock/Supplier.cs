using System;
using System.Collections.Generic;
using Core.Entities.Catalog;

namespace Core.Entities.Stock
{
    public class Supplier 
    {
        public Supplier()
        {
            Drugs = new HashSet<Drug>();
            Stockentries = new HashSet<Stockentries>();
        }
        public int SupplierId { get; set; }
        public int? Addressid { get; set; }
        public string SupplierName { get; set; }
        public string Cnpj { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual ICollection<Stock.Stockentries> Stockentries { get; set; }
    }
}
