using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public class Clipago : BaseEntity
    {        
        public string Cliente { get; set; }
        public DateTime? Data { get; set; }
        public double? Valor { get; set; }
        public double? Credito { get; set; }
    }
}
