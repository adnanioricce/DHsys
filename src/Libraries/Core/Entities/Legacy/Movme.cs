using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Movme : BaseEntity
    {
        
        public string Prcodi { get; set; }
        public double? Prqtde { get; set; }
        public double? VlUnit { get; set; }
        public double? Vlliquid { get; set; }
        public double? TotDescon { get; set; }
        public string Ticket { get; set; }
        public string Bacodi { get; set; }
        public DateTime? Data { get; set; }
        public string Tipo { get; set; }
        public string Tpvd { get; set; }
        public string Cancelado { get; set; }
        public double? VlTot { get; set; }
        public double? TotComis { get; set; }
        public string Pedido { get; set; }
        public string Codcli { get; set; }
    }
}
