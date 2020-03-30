﻿using System;
using System.Collections.Generic;
using Core.Entities.Stock;

namespace Core.Entities.Catalog
{
    public class Drug : Product
    {
        public Drug()
        {
            Druginformation = new HashSet<Druginformation>();
            Drugprices = new HashSet<Drugprices>();
            Stockentries = new HashSet<Stockentries>();
        }
        
        public int? BaseDrugId { get; set; }
        public int? SupplierId { get; set; }
        /// <summary>
        /// Legacy property, keeped for compability purposes. Ignore it
        /// </summary>
        /// <value></value>
        public string PrCdse { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        /// <summary>
        /// Get or set the DrugName. the business has it's own way to name drugs
        /// </summary>
        /// <value></value>
        public string DrugName { get; set; }        
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
        /// Get or Set the cost for the business to buy this drug
        /// </summary>
        /// <value></value>
        public decimal? DrugCost { get; set; }
        /// <summary>
        /// Get or Set The dosage writed on the drug
        /// </summary>
        /// <value></value>
        public double? DosageInMg { get; set; }        
        /// <summary>
        /// Get or set The substance in the drug.
        /// TODO:Change this to a entity called Substance, with a relation of 1(drug)-to-n(substances)
        /// </summary>
        /// <value></value>        
        public string Substance { get; set; }
        /// <summary>
        /// Get or set the number of the lot in the stock entry. obrigatory value for antibiotics and prescripted drugs
        /// </summary>
        /// <value></value>
        public string LotNumber { get; set; }
        /// <summary>
        /// Get or set The description of the Type of use of this drug
        /// </summary>
        /// <value></value>
        public string TypeOfUse { get; set; }
        /// <summary>
        /// Get or set the minimal age that this drug should be required
        /// </summary>
        /// <value></value>
        public int? MinimalAgeOfUse {get; set;}
        /// <summary>
        /// Get or set if this Drug need prescription to be selled
        /// </summary>
        /// <value></value>
        public bool PrescriptionNeeded { get; set; }
        /// <summary>
        /// Get or set if price of drug is fixed by supplier/market/ or other entity(in the human context)
        /// </summary>
        /// <value></value>
        public bool IsPriceFixed { get; set; }
        /// <summary>
        /// Get or set a link to the bule of the drug 
        /// </summary>
        /// <value></value>
        public string DigitalBuleLink { get; set; }        
        /// <summary>
        /// Get or set the reference to the Supplier Entity
        /// </summary>
        /// <value></value>
        public virtual Supplier Supplier { get; set; }
        /// <summary>
        /// Get or set the reference collection of Drug informations
        /// </summary>
        /// <value></value>
        public virtual ICollection<Druginformation> Druginformation { get; set; }
        public virtual ICollection<Catalog.Drugprices> Drugprices { get; set; }
        public virtual ICollection<Stockentries> Stockentries { get; set; }
    }
}
