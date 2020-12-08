using System;
using System.Collections.Generic;
using Core.Entities.Catalog;

namespace Core.Entities.Stock
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {            
            Stockentries = new HashSet<StockEntry>();
        }        
        public int? AddressId { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }

        public virtual Address Address { get; set; }        
        public virtual ICollection<Stock.StockEntry> Stockentries { get; set; }
    }
}
