using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Troco18 : BaseEntity
    {        
        public double? TrocoIni { get; set; }
        public bool Initroco { get; set; }
        public DateTime? Data { get; set; }
    }
}
