using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Etiqueta
    {
        public int Id { get; set; }
        public string Prcodi { get; set; }
        public string Prdesc1 { get; set; }
        public string Prdesc2 { get; set; }
        public double? Prcons { get; set; }
    }
}
