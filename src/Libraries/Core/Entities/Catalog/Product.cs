using Core.Entities.Legacy;
using Core.Entities.Stock;
using System;
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
        /// On legacy model:Prncms
        /// </summary>
        /// <value></value>
        public string Ncm { get; set; } 
        /// <summary>
        /// Get or Set Quantity of product on stock.
        /// On legacy model:Prestq
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
        /// Get or Set The price of the product to end customer.
        /// On legacy model:Prfinal
        /// </summary>
        /// <value></value>
        public decimal? EndCustomerPrice { get; set; }
        /// <summary>
        /// Get or Set the buy cost of the product
        /// </summary>
        /// <value></value>
        public decimal CostPrice { get; set; }
        public decimal SavingPercentage { get; set; }
        /// <summary>
        /// Get or set the barcode to be used to search for the product.
        /// On legacy model:Prbarra
        /// </summary>
        /// <value></value>
        public string BarCode { get; set; }        
        /// <summary>
        /// Get or set the description of the product.
        /// On legacy model:Prdesc
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Get or set the physical place where this product remains.
        /// On legacy model:Prsecao
        /// </summary>
        /// <value></value>
        public string Section { get; set; }
        /// <summary>
        /// Get or set max discount percentage that a product can be selled normally.
        /// On legacy model:desc_max
        /// </summary>
        public decimal MaxDiscountPercentage { get; set; }        
        /// <summary>
        /// Get or set the absolute value of discount in product.        
        /// </summary>
        public decimal DiscountValue { get; set; }
        
        /// <summary>
        /// Get or set the comission value from each product selled
        /// On legacy model:comissao
        /// </summary>
        public string Commission { get; set; }
        /// <summary>
        /// Get or set the ICMS, a brazil specific Tax.
        /// On legacy model:Pricms
        /// </summary>
        public decimal ICMS { get; set; } = 18;
        /// <summary>
        /// Get or set the minimun stock that this product should have.
        /// On legacy model:est_minimo
        /// </summary>
        public int MinimumStock { get; set; } = 1;
        public string MainSupplierName { get; set; }
        /// <summary>
        /// Get or set the Many-To-Many reference to the Supplier Entity
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
        public virtual ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();
        public virtual ICollection<ProductStockEntry> Stockentries { get; set; } = new List<ProductStockEntry>();
        /// <summary>
        /// get or set collection of Shelf life 
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductShelfLife> ShelfLifes { get; set; } = new List<ProductShelfLife>();        
        #region Legacy field models
        /// <summary>
        /// Get or set a reference to the legacy model of the current object
        /// </summary>
        /// <value>the legacy model version of current object</value>
        public virtual Produto Produto { get; set; }
        public int? ProdutoId { get; set; }        
        #endregion
        
        #region Methods
        public virtual void UpdatePrice(ProductPrice price)
        {
            this.ProductPrices.Add(price);
            this.EndCustomerPrice = price.EndCustomerDrugPrice;
            this.CostPrice = price.CostPrice;
            this.SavingPercentage = price.CalculatePercentageSaving();
            this.Produto.Prfabr = Convert.ToDouble(this.CostPrice);
            this.Produto.Prcons = Convert.ToDouble(this.EndCustomerPrice);            
        }
        public virtual void UpdatePrice(decimal newEndCustomerPriceValue,decimal newCostPrice)
        {
            var price = new ProductPrice{
                Pricestartdate = DateTimeOffset.UtcNow,
                EndCustomerDrugPrice = newEndCustomerPriceValue,
                CostPrice = newCostPrice,
                ProductId = this.Id,
            };
            UpdatePrice(price);
        }
        #endregion
    }   
}