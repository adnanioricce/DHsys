using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public  class Debcli
    {
        public int Id { get; set; }
        public string Clcodi { get; set; }
        public string Bacodi { get; set; }
        public string Prcodi { get; set; }
        public DateTime? Cldata { get; set; }
        public double? Clqtde { get; set; }
        public string Clpago { get; set; }
        public double? Cldesc { get; set; }
        public string Cltick { get; set; }
        public string Clbalc { get; set; }
        public string Clobs { get; set; }
        public string Descomp { get; set; }
        public double? Comissao { get; set; }
        public double? VlPago { get; set; }
        public DateTime? DtPagto { get; set; }
    }
}
