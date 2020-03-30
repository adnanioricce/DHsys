using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Despesas
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Historico { get; set; }
        public double? Valor { get; set; }
        public string Caixa { get; set; }
    }
}
