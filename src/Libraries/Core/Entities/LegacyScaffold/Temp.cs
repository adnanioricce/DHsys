using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Temp
    {
        public int Id { get; set; }
        public string Prcodi { get; set; }
        public string Descricao { get; set; }
        public double? Prcons { get; set; }
        public double? Desconto { get; set; }
        public double? Prconsd { get; set; }
        public double? VlTotal { get; set; }
        public double? Qtde { get; set; }
    }
}
