using System;
using System.Collections.Generic;

namespace Core.Entities.Catalog
{
    public class DrugInformation : BaseEntity
    {        
        public int? DrugId { get; set; }
        public string Indication { get; set; }
        public string CounterIndication { get; set; }
        public string HowWorks { get; set; }
        public string HowToUse { get; set; }
        /// <summary>
        /// Get or set The description of the Type of use of this drug
        /// </summary>
        /// <value></value>
        public string TypeOfUse { get; set; }
        /// <summary>
        /// Get or set the minimal age that this drug should be reqCorered
        /// </summary>
        /// <value></value>
        public int? MinimalAgeOfUse { get; set; }
        public string Substances { get; set; }
        public string UserBule { get; set; }
        public string ProfessionalBule { get; set; }
        public virtual Drug Drug { get; set; }
    }
}
