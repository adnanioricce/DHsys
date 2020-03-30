using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Numped
    {
        public int Id { get; set; }
        public string Fornec { get; set; }
        public string Przpagto { get; set; }
        public double? Desconto { get; set; }
        public string Numero { get; set; }
        public string Przentrega { get; set; }
    }
}
