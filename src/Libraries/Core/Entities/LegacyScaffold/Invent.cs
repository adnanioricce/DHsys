using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public  class Invent
    {
        public int Id { get; set; }
        public string Prcodi { get; set; }
        public string Prreg { get; set; }
        public string Prdesc { get; set; }
        public string Lote { get; set; }
        public double? Qtde { get; set; }
        public string Tpmed { get; set; }
    }
}
