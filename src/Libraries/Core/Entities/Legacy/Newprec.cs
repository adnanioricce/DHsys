using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Newprec : BaseEntity
    {
        
        public string Prcodi { get; set; }
        public double? Prcons { get; set; }
        public double? Prconscv { get; set; }
        public double? Prfabr { get; set; }
        public DateTime? Prcddt { get; set; }
        public double? Prcdlucr { get; set; }
    }
}
