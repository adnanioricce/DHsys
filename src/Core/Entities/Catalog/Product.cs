using System.Collections;
using System.Collections.Generic;

namespace Core.Entities.Catalog
{
    /// <summary>
    /// Product entity. It's used mainly as base entity
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Get or Set product NCM.
        /// https://pt.wikipedia.org/wiki/Nomenclatura_Comum_do_Mercosul
        /// </summary>
        /// <value></value>
        public string Ncm { get; set; }
        /// <summary>
        /// Get or Set Quantity of product on stock
        /// </summary>
        /// <value></value>
        public int? QuantityInStock { get; set; }
        /// <summary>
        /// Get or set Reorder Level, to notify when this product should be reordered 
        /// </summary>
        /// <value></value>
        public int? ReorderLevel { get; set; }
        /// <summary>
        /// Get or Set the quantity to be reordered if minimal value for ReorderLevel property is reached
        /// </summary>
        /// <value></value>
        public int? ReorderQuantity { get; set; }
        /// <summary>
        /// Get or Set The price of the product to end customer
        /// </summary>
        /// <value></value>
        public decimal? EndCustomerPrice { get; set; }
        /// <summary>
        /// Get or set the barcode to be used to search for the product
        /// </summary>
        /// <value></value>
        public string BarCode { get; set; }
        /// <summary>
        /// Get or set the code to search for the product
        /// </summary>
        /// <value></value>
        public string Code { get; set; }
        /// <summary>
        /// Get or set the description of the product
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Get or set the physical place where this product remains
        /// </summary>
        /// <value></value>
        public string Section { get; set; }
        /// <summary>
        /// get or set collection of Shelf life 
        /// </summary>
        /// <value></value>
        public ICollection<ProductShelfLife> ShelfLifes { get; set; } = new List<ProductShelfLife>();
    }   
}