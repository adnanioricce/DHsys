using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public  class Ranclivl
    {
        public int Id { get; set; }
        public string NFiscal { get; set; }
        public string Ticket { get; set; }
        public double? TotVen { get; set; }
        public string Tipo { get; set; }
        public DateTime? Data { get; set; }
        public string Bacodi { get; set; }
        public string Cancelado { get; set; }
        public string Caixa { get; set; }
        public string Hora { get; set; }
        public string Codcli { get; set; }
    }
}
