using System;
using System.Collections.Generic;

namespace Legacy.Entities
{
    public  class Despesas  
    {        
        public DateTime? Data { get; set; }
        public string Historico { get; set; }
        public double? Valor { get; set; }
        public string Caixa { get; set; }
    }
}
