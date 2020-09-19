using System;
using System.Collections.Generic;

namespace Legacy.Entities
{
    public class Caixa  
    {        
        public string CxAtend { get; set; }
        public DateTime? CxData { get; set; }
        public double? CxValor { get; set; }
        public DateTime? CxRec { get; set; }
        public string CxAdm { get; set; }
        public double? CxCart { get; set; }
        public string CxTipo { get; set; }
    }
}
