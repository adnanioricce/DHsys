using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public class Cadprom : BaseEntity
    {        
        public string Lacodi { get; set; }
        public string Fonome { get; set; }
        public string Fotele { get; set; }
        public DateTime? Valid { get; set; }
    }
}
