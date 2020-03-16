using System;
using System.Collections.Generic;

namespace Core.Entities.Catalog
{
    public partial class Druginformation
    {
        public int DrugInformationId { get; set; }
        public int? DrugId { get; set; }
        public string Indication { get; set; }
        public string CounterIndication { get; set; }
        public string HowWorks { get; set; }
        public string HowToUse { get; set; }
        public string Substances { get; set; }
        public string UserBule { get; set; }
        public string ProfessionalBule { get; set; }
        public virtual Drug Drug { get; set; }
    }
}
