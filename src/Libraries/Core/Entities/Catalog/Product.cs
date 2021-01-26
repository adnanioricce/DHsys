using Core.Entities.Financial;
using Core.Entities.Media;
using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Catalog
{    
    public class Product : BaseEntity
    {
        public Product()
        {

        }
        public int? BaseProductId { get; set; }        
        public int? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerCountry { get; set; }
        public RiskClass RiskClass { get; set; }
        /// <summary>
        /// Get or set the Name.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
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

        public float Concentration { get; set; }
        public string FisicForm { get; set; }
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
        public string UseRestriction { get; set; }
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
        /// </summary>
        /// <value></value>
        public string Ncm { get; set; } 
        /// <summary>
        /// Get or Set Quantity of product on stock.
        /// On legacy model:Prestq
        /// </summary>
        /// <value></value>
        public int QuantityInStock { get; protected set; }
        /// <summary>
        /// Get or set the last time that this product was present in the creation of a stock entry
        /// </summary>
        public DateTimeOffset? LastStockEntry { get; protected set; }
        /// <summary>
        /// Get or set Reorder Level, to notify when this product should be reordered 
        /// </summary>
        /// <value></value>
        public int ReorderLevel { get; set; }
        /// <summary>
        /// Get or Set the quantity to be reordered if minimal value for ReorderLevel property is reached
        /// </summary>
        /// <value></value>
        public int ReorderQuantity { get; set; }        

        /// <summary>
        /// Get or Set The price of the product to end customer.        
        /// </summary>
        /// <value></value>
        public decimal EndCustomerPrice { get; protected set; }
        /// <summary>
        /// Get or Set the buy cost of the product
        /// </summary>
        /// <value></value>
        public decimal CostPrice { get; protected set; }
        public decimal SavingPercentage { get; protected set; }
        /// <summary>
        /// Get or set the barcode to be used to search for the product.        
        /// </summary>
        /// <value></value>
        public string BarCode { get; set; }        
        /// <summary>
        /// Get or set the description of the product.        
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Get or set the physical place where this product remains.        
        /// </summary>
        /// <value></value>
        public string Section { get; set; }
        /// <summary>
        /// Get or set max discount percentage that a product can be selled normally.        
        /// </summary>
        public decimal MaxDiscountPercentage { get; set; }        
        /// <summary>
        /// Get or set the absolute value of discount in product.        
        /// </summary>
        public decimal DiscountValue { get; set; }
        
        /// <summary>
        /// Get or set the comission value from each product selled        
        /// </summary>
        public string Commission { get; set; }
        /// <summary>
        /// Get or set the ICMS, a brazil specific Tax.        
        /// </summary>
        public decimal ICMS { get; set; } = 18;
        /// <summary>
        /// Get or set the minimun stock that this product should have.        
        /// </summary>
        public int MinimumStock { get; set; } = 1;
        /// <summary>
        /// Get or set the name of the main supplier
        /// </summary>
        public string MainSupplierName { get; set; }
        
        public string OwnerOfRegistry { get; set; }
        public string RegistryCode { get; set; }
        public DateTime RegistryPublicationDate { get; set; }
        public DateTimeOffset DateOfRegistryUpdate { get; set; }
        public string RegistryValidity { get; set; }
        public string MedicalProductModel { get; set; }
        public Stripes Stripe { get; set; }
        
        /// <summary>
        /// Get or set the collection reference to the Supplier Entity
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; protected set; } = new List<ProductSupplier>();
        /// <summary>
        /// Get or set collection of previous and current entity prices
        /// </summary>
        public virtual ICollection<ProductPrice> ProductPrices { get; protected set; } = new List<ProductPrice>();
        /// <summary>
        /// Get or set collection of Stock entries that this entity is present
        /// </summary>
        public virtual ICollection<ProductStockEntry> Stockentries { get; protected set; } = new List<ProductStockEntry>();
        /// <summary>
        /// Get or set collection of media used by this entity
        /// </summary>
        public virtual ICollection<ProductMedia> ProductMedias { get; protected set; } = new List<ProductMedia>();
        /// <summary>
        /// get or set collection of Shelf life 
        /// </summary>
        /// <value></value>
        public virtual ICollection<ProductShelfLife> ShelfLifes { get; set; } = new List<ProductShelfLife>();
        /// <summary>
        /// Get or set collection of categories that this entity is included
        /// </summary>
        public virtual ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
        public virtual ICollection<StockChange> StockChanges { get; set; } = new List<StockChange>();
        public virtual ICollection<ProductTax> ProductTaxes { get; set; } = new List<ProductTax>();
        #region Public Methods
        public virtual void SetNewPrice(ProductPrice price)
        {
            this.ProductPrices.Add(price);
            this.EndCustomerPrice = price.EndCustomerDrugPrice;
            this.CostPrice = price.CostPrice;
            this.SavingPercentage = price.CalculatePercentageSaving();
        }
        public virtual void UpdatePrice(decimal newEndCustomerPriceValue,decimal newCostPrice,DateTimeOffset startDate)
        {
            var price = ProductPrice.CreateNewPrice(this,newCostPrice,newEndCustomerPriceValue,startDate);                
            SetNewPrice(price);
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
        /// <summary>
        /// Add the product to a specified category
        /// </summary>
        /// <param name="category">the category to add the product to</param>
        public virtual void AddToCategory(Category category)
        {
            if(category is null)
            {
                throw new ArgumentNullException("can't add a null reference of a category object to a product entity");
            }            
            if (this.Categories.Any(c => c.CategoryId == category.Id)) return;
            if (category.Id == 0)
            {
                var productCategory = new ProductCategory(this,category);                
                this.Categories.Add(productCategory);
                return;
            }
            this.Categories.Add(new ProductCategory(this,category));
        }
        /// <summary>
        /// Add new tax to the current <see cref="Product"/> object
        /// </summary>
        /// <param name="tax">the <see cref="Tax"/> to be added to the <see cref="Product"/> object</param>
        public virtual void AddTax(Tax tax)
        {
            if(tax is null)
            {
                throw new ArgumentNullException("can't add a null reference of a tax to a product ");
            }
            if (this.ProductTaxes.Any(c => c.TaxId == tax.Id)) return;
            if (tax.Id == 0)
            {                
                var productTax = new ProductTax(this, tax);
                this.ProductTaxes.Add(productTax);
                return;
            }            
            this.ProductTaxes.Add(new ProductTax(this.Id, tax.Id));
        }
        /// <summary>
        /// update the stock quantity of the product
        /// </summary>
        /// <param name="stockChange">the change to be applied on the product</param>
        public virtual void UpdateStock(StockChange stockChange)
        {
            //? Throw a exception or simply set StockQuantity to zero?
            int quantity = stockChange.Quantity + this.QuantityInStock;
            var isQuantityBiggerThanExisting = stockChange.Quantity < 0 ? quantity < 0 : false;
            if (isQuantityBiggerThanExisting)
            {
                throw new ArgumentException("the given stock change is bigger than the available product in stock");
            }
            this.StockChanges.Add(stockChange);
            this.QuantityInStock += stockChange.Quantity;
            this.LastStockEntry = stockChange.CreatedAt;
        }
        public virtual ProductMedia GetThumbnailImage()
        {
            return ProductMedias.Where(p => p.IsThumbnail && p.Media.Type == Media.MediaType.Image).FirstOrDefault();
        }
        
        #endregion       
    }
}