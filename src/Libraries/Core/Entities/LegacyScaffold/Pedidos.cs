using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Pedidos
    {
        public int Id { get; set; }
        public string Prcodi { get; set; }
        public double? Prqtde { get; set; }
        public string Prcdla { get; set; }
        public double? Prfabr { get; set; }
        public string Status { get; set; }
        public DateTime? Prdata { get; set; }
    }
}
