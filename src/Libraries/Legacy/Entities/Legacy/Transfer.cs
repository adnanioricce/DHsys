using System;
using System.Collections.Generic;

namespace Legacy.Entities
{
    public  class Transfer  
    {
        
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
