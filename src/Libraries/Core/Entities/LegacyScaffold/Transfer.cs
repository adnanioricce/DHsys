using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public  class Transfer
    {
        public int Id { get; set; }
        public DateTime? Trdata { get; set; }
        public string Balcon { get; set; }
        public string Prcodi { get; set; }
        public double? Qtde { get; set; }
        public double? Prcons { get; set; }
        public string Etiqueta { get; set; }
        public string Impresso { get; set; }
        public string Filcodi { get; set; }
        public string Hora { get; set; }
    }
}
