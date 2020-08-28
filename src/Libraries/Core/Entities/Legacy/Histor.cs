using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Histor : BaseEntity
    {
        
        public string Distrib { get; set; }
        public string Notafis { get; set; }
        public DateTime? Vencto { get; set; }
        public DateTime? Recebto { get; set; }
        public string Pedido { get; set; }
        public double? Total { get; set; }
        public double? Desconto { get; set; }
    }
}
