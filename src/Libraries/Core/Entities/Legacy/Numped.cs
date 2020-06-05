using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Numped : BaseEntity
    {
        
        public string Fornec { get; set; }
        public string Przpagto { get; set; }
        public double? Desconto { get; set; }
        public string Numero { get; set; }
        public string Przentrega { get; set; }
    }
}
