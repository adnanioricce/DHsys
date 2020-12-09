using Core.Entities.Media;
using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Catalog
{
    /// <summary>
    /// Product entity. It's used mainly as base entity    
    /// </summary>
    public class Product : BaseEntity
    {
        public int? BaseDrugId { get; set; }
        /// <summary>
        /// Legacy property, keeped for compability purposes. Ignore it
        /// </summary>
        /// <value></value>
        public string PrCdse { get; set; }
        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        /// <summary>
        /// Get or set the fixed name fixed by some real life entity
        /// </summary>
        /// <value></value>
        public string CommercialName { get; set; }
        /// <summary>
        /// Get or Set The classification of the medication
        /// </summary>
        /// <value></value>
        public string Classification { get; set; }

        /// <summary>
        /// Get or set the string representation of the drug dosage
        /// </summary>
        public string Dosage { get; set; }
        /// <summary>
        /// Get or Set The dosage writed on the drug
        /// </summary>
        /// <value></value>
        public double? AbsoluteDosageInMg { get; set; }
        /// <summary>
        /// Get or set The substance in the drug.
        /// TODO:Change this to a entity called Substance, with a relation of 1(drug)-to-n(substances)
        /// </summary>
        /// <value></value>        
        public string ActivePrinciple { get; set; }
        /// <summary>
        /// Get or set the number of the lot in the stock entry. obrigatory value for antibiotics and prescripted drugs
        /// </summary>
        /// <value></value>
        public string LotNumber { get; set; }

        /// <summary>
        /// Get or set if this Drug need prescription to be selled
        /// </summary>
        /// <value></value>
        public bool PrescriptionNeeded { get; set; }
        /// <summary>
        /// Get or set if price of drug is fixed by supplier/market/ or other entity(in the human context)
        /// </summary>
        /// <value></value>
        public bool IsPriceFixed { get; set; } = false;
        /// <summary>
        /// Get or set a link to the bule of the drug 
        /// </summary>
        /// <value></value>
        public string DigitalBuleLink { get; set; }
        /// <summary>
        /// Get or set the identifier code of the laboratory of this drug
        /// </summary>
        /// <value></value>
        public string LaboratoryCode { get; set; }
        /// <summary>
        /// Get or set the name of the laboratory that this drug was manufactured
        /// </summary>
        public string LaboratoryName { get; set; }
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
        /// <summary>
        /// Get or set the name of the main supplier
        /// </summary>
        public string MainSupplierName { get; set; }
        /// <summary>
        /// Get or set the Name.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        public string RegistryCode { get; set; }
        
        /// <summary>
        /// Get or set the collection reference to the Supplier Entity
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new List<ProductSupplier>();
        /// <summary>
        /// Get or set collection of previous and current entity prices
        /// </summary>
        public virtual ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();
        /// <summary>
        /// Get or set collection of Stock entries that this entity is present
        /// </summary>
        public virtual ICollection<ProductStockEntry> Stockentries { get; set; } = new List<ProductStockEntry>();
        /// <summary>
        /// Get or set collection of media used by this entity
        /// </summary>
        public virtual ICollection<ProductMedia> ProductMedias { get; set; } = new List<ProductMedia>();
        /// <summary>
        /// get or set collection of Shelf life 
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductShelfLife> ShelfLifes { get; set; } = new List<ProductShelfLife>();
        /// <summary>
        /// Get or set collection of categories that this entity is included
        /// </summary>
        public virtual ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();

        #region Methods
        public virtual void UpdatePrice(ProductPrice price)
        {
            this.ProductPrices.Add(price);
            this.EndCustomerPrice = price.EndCustomerDrugPrice;
            this.CostPrice = price.CostPrice;
            this.SavingPercentage = price.CalculatePercentageSaving();            
        }        
        public virtual void UpdatePrice(decimal newEndCustomerPriceValue,decimal newCostPrice,DateTimeOffset? startDate = null)
        {
            var price = new ProductPrice{
                Pricestartdate = startDate.HasValue ? startDate : DateTimeOffset.UtcNow,
                EndCustomerDrugPrice = newEndCustomerPriceValue,
                CostPrice = newCostPrice,                
                ProductId = this.Id,
            };
            UpdatePrice(price);
        }
        public virtual void AddProductImage(ProductMedia media)
        {
            ProductMedias.Add(media);
        }
        public virtual void AddNewProductMedia(MediaResource media,bool isThumbnail = false)
        {
            var productMedia = new ProductMedia
            {
                Media = media,
                Product = this,
                IsThumbnail = isThumbnail,                
            };
            AddProductImage(productMedia);
        }
        public virtual void AddSupplier(Supplier supplier)
        {
            if(!this.ProductSuppliers.Any(s => s.SupplierId == supplier.Id))
            {
                var productSupplier = new ProductSupplier
                {
                    Product = this,
                    Supplier = supplier,                    
                };
                ProductSuppliers.Add(productSupplier);
                
            }
        }
        
        public virtual ProductMedia GetThumbnailImage()
        {
            return ProductMedias.Where(p => p.IsThumbnail && p.Media.Type == Media.MediaType.Image).FirstOrDefault();
        }
        
        #endregion
    }   
}