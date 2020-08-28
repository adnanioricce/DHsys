using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Fechconv : BaseEntity
    {        
        public string Fucdem { get; set; }
        public DateTime? Data { get; set; }
        public double? Valor { get; set; }
    }
}
