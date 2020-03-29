using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Clipago
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime? Data { get; set; }
        public double? Valor { get; set; }
        public double? Credito { get; set; }
    }
}
