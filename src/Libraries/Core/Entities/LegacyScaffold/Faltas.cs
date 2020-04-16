using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Faltas
    {
        public int Id { get; set; }
        public string Prcodi { get; set; }
        public DateTime? Data { get; set; }
        public string Balcon { get; set; }
    }
}
