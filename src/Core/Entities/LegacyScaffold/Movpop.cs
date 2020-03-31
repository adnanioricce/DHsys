using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Movpop
    {
        public int Id { get; set; }
        public string Prcodi { get; set; }
        public double? Prqtde { get; set; }
        public double? VlUnit { get; set; }
        public double? VlliqCored { get; set; }
        public double? TotDescon { get; set; }
        public string Ticket { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Datarec { get; set; }
        public string Ecf { get; set; }
        public string Cancelado { get; set; }
        public double? VlTot { get; set; }
        public double? Compdia { get; set; }
        public double? Compmes { get; set; }
        public string BalcCpf { get; set; }
        public string Cpfcli { get; set; }
        public string Senha { get; set; }
        public string Crm { get; set; }
    }
}
