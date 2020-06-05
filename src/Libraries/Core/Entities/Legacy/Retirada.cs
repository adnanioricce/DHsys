using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Retirada : BaseEntity
    {
        
        public DateTime? Data { get; set; }
        public double? Valordh { get; set; }
        public double? Valorch { get; set; }
        public string Hora { get; set; }
        public string Caixa { get; set; }
    }
}
