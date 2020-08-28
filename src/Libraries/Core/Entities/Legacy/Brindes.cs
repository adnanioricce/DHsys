using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public class Brindes : BaseEntity
    {        
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public double? Pontos { get; set; }
        public double? Qtde { get; set; }
    }
}
