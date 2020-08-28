using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Usoint : BaseEntity
    {
        
        public DateTime? Data { get; set; }
        public string Prcodi { get; set; }
        public double? Qtde { get; set; }
    }
}
