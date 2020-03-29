using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Chdevol
    {
        public int Id { get; set; }
        public string Cheque { get; set; }
        public string Agencia { get; set; }
        public string Banco { get; set; }
        public string Conta { get; set; }
        public double? Valor { get; set; }
        public DateTime? Datae { get; set; }
        public DateTime? Data { get; set; }
        public string Cliente { get; set; }
    }
}
