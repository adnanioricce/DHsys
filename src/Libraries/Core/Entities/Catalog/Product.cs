using Core.Entities.LegacyScaffold;
using Core.Entities.Stock;
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
        public int MinimumStock { get; set; }
        public string MainSupplierName { get; set; }
        /// <summary>
        /// Get or set the Many-To-Many reference to the Supplier Entity
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>(); 
        //Fields with unsure function
        #region Legacy field models
        public virtual Produto Produto { get; set; }
        public int? ProdutoId { get; set; }
        //public string ProductData { get; set; }
        
        ////TODO:Try to find what  theses fields are for
        //public string RegistroMs { get; set; }
        //public string PrecoAPrazo { get; set; }
        //public string EtiquetaPadrao { get; set; }
        //public string EtiquetaBarras { get; set; }
        //public string EtiquetaGrafica { get; set; }
        //public string CodigoPadrao { get; set; }
        //public string FarmaciaPopular { get; set; }
        //public string IsencaoPISOuCONFISN { get; set; }
        //public string Un { get; set; }
        //public string Fixa { get; set; }
        //public string Localizacao { get; set; }
        //public string Condicao { get; set; } // -> Enum
        //public string Ate { get; set; } // -> DateTime
        //public string Sal { get; set; }
        //public int Embalagem { get; set; }
        //public string prdtul { get; set; }
        //public string prcddt { get; set; }
        //public decimal prcdlucr { get; set; }
        //public string prcdimp { get; set; }
        //public string prcdimp2 { get; set; }
        //public string premb { get; set; }
        //public string prentr { get; set; }
        //public string ul_ven { get; set; }
        //public string ultped { get; set; }
        //public string prclas { get; set; }
        //public string prmesant { get; set; }
        //public string ultpreco { get; set; }
        //public string prdesconv { get; set; }
        //public string prpopular { get; set; }
        //public string codesta { get; set; }
        ////Venda anterior e venda atual?
        //public int vendatu { get; set; }
        //public int vendant { get; set; }
        #endregion
        /// <summary>
        /// get or set collection of Shelf life 
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductShelfLife> ShelfLifes { get; set; } = new List<ProductShelfLife>();

        

    }   
}