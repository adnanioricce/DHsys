using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Merctran : BaseEntity
    {
        
        public string Prcodi { get; set; }
        public string Descricao { get; set; }
        public double? Qtde { get; set; }
        public double? Prcons { get; set; }
        public double? Desconto { get; set; }
        public double? Estoque { get; set; }
        public string Etiqueta { get; set; }
        public double? Prconsd { get; set; }
        public string Comissao { get; set; }
        public double? VlTotal { get; set; }
    }
}
