using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public class Brindes
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public double? Pontos { get; set; }
        public double? Qtde { get; set; }
    }
}
