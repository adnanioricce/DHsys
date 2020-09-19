using System;
using System.Collections.Generic;

namespace Legacy.Entities
{
    public class Chdevol  
    {        
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
