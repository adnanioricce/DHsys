using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Cadprom
    {
        public int Id { get; set; }
        public string Lacodi { get; set; }
        public string Fonome { get; set; }
        public string Fotele { get; set; }
        public DateTime? Valid { get; set; }
    }
}
