using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public class Balcon : BaseEntity
    {        
        public string Bacodi { get; set; }
        public string Banome { get; set; }
        public double? Bacomi { get; set; }
        public double? Badevol { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public double? ComisBo { get; set; }
        public double? ComisPer { get; set; }
        public double? ComisAce { get; set; }
        public double? ComisVar { get; set; }
        public double? ComisEti { get; set; }
        public double? ComisPerc { get; set; }
        public double? ComisOut { get; set; }
    }
}
