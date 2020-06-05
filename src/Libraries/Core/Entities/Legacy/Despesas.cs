using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Despesas : BaseEntity
    {        
        public DateTime? Data { get; set; }
        public string Historico { get; set; }
        public double? Valor { get; set; }
        public string Caixa { get; set; }
    }
}
