using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Faltas : BaseEntity
    {
        
        public string Prcodi { get; set; }
        public DateTime? Data { get; set; }
        public string Balcon { get; set; }
    }
}
