using System;
using Core.Entities.LegacyScaffold;

namespace Core.Entities.Catalog
{
    public class ProductShelfLife : BaseEntity
    {
        public int ProductId { get; set; }
        public int StockEntryId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }   
        /// <summary>
        /// Get or set References to legacy property entity
        /// </summary>
        /// <value></value>
        public Produto LegacyProduct { get; set; }
    }   
}