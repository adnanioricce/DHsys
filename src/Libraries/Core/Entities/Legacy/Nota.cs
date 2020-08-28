using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Nota : BaseEntity
    {
        
        public string NFiscal { get; set; }
        public string Cliente { get; set; }
        public double? Nvalor { get; set; }
        public double? Base { get; set; }
        public double? Icms { get; set; }
        public double? Basesub { get; set; }
        public double? Icmssub { get; set; }
        public double? Nbase7 { get; set; }
        public double? Nicms7 { get; set; }
        public double? Nbase12 { get; set; }
        public double? Nicms12 { get; set; }
        public double? Nbase18 { get; set; }
        public double? Nicms18 { get; set; }
        public double? Nbase25 { get; set; }
        public double? Nicms25 { get; set; }
        public string Natureza { get; set; }
        public string NNatu { get; set; }
        public DateTime? Ndata { get; set; }
        public string Ncancelada { get; set; }
    }
}
