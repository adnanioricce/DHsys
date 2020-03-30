using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Usoint
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Prcodi { get; set; }
        public double? Qtde { get; set; }
    }
}
