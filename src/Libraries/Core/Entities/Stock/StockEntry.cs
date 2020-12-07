using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Catalog;

namespace Core.Entities.Stock
{
    public class StockEntry : BaseEntity
    {
        protected decimal? _totalCost = 0.0m;        
        /// <summary>
        /// Get or Set the total count of items related with the this <see cref="StockEntry"/>
        /// </summary>
        public int? ItemsCount { get { return Items.Count; } }
        /// <summary>
        /// Get or Set the number of the NF(Nota fiscal) of this <see cref="StockEntry"/>, for business that need to register it.
        /// </summary>
        public string NfNumber { get; set; }
        /// <summary>
        /// Get or Set the date in which the NF related with this <see cref="StockEntry"/> was emited
        /// </summary>
        public DateTime? NfEmissionDate { get; set; }
        // ///<summary>
        // /// Get or set the date in which this <see cref="StockEntry"/> was registered
        // ///</summary>
        // public DateTime EntryDate { get; set; }
        // ///<summary>
        // /// Get or set the Id of the optional relation between this entity and Supplier entity
        // ///</summary>
        // public int? SupplierId { get; set; }
        /// <summary>
        /// Get or Set the total cost of all the items of this <see cref="StockEntry"/>
        /// </summary>
        // Some problems with the mapping when trying to customize the get and set properties
        // Need to think in a way to define custom mappings now
        public decimal? Totalcost { get; set; }
        public virtual ICollection<ProductStockEntry> Items { get; set; } = new List<ProductStockEntry>();        
        private decimal? CalculateStockEntryCost()
        {
            return Items.Sum(item => item.Quantity * item.Product.CostPrice);
        }        
        
        public void AddEntry(Drug drug,DateTime? maturityDate,int quantity,string lotCode)
        {
            if(drug is null) return;
            var entry = new ProductStockEntry
            {
                Product = drug,
                StockEntry = this,
                Quantity = quantity,
                LotCode = lotCode
            };
            if (maturityDate.HasValue)
            {
                entry.ProductMaturityDate = maturityDate.Value;
            }
            AddEntry(entry);
        }
        public void AddEntry(ProductStockEntry entry)
        {            
            if(entry.StockEntry is null)
            {
                entry.StockEntry = this;
            }
            this.Items.Add(entry);
        }
    }
}
