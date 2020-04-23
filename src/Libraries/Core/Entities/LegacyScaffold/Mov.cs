using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Mov
    {
        public int Id { get; set; }
        public string NFiscal { get; set; }
        public string Ticket { get; set; }
        public double? TotVen { get; set; }
        public double? TotAnt { get; set; }
        public string Tipo { get; set; }
        public string Tpvd { get; set; }
        public string Ecf { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime? Data { get; set; }
        public string Bacodi { get; set; }
        public string Cancelado { get; set; }
        public string Caixa { get; set; }
        public string Hora { get; set; }
        public double? Dinheiro { get; set; }
        public double? Cheque { get; set; }
        public double? Chequepre { get; set; }
        public double? Cartaoc { get; set; }
        public double? Popular { get; set; }
        public string Admcart { get; set; }
        public string Codcli { get; set; }
    }
}
