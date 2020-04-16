using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Newprec
    {
        public int Id { get; set; }
        public string Prcodi { get; set; }
        public double? Prcons { get; set; }
        public double? Prconscv { get; set; }
        public double? Prfabr { get; set; }
        public DateTime? Prcddt { get; set; }
        public double? Prcdlucr { get; set; }
    }
}
