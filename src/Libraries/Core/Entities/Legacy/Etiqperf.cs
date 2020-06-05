using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Etiqperf : BaseEntity
    {
        
        public string Prcodi { get; set; }
        public string Prdesc1 { get; set; }
        public string Prdesc2 { get; set; }
        public double? Prcons { get; set; }
        public double? Prconsf { get; set; }
    }
}
