using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Servico
    {
        public int Id { get; set; }
        public string Svcodi { get; set; }
        public string Svdesc { get; set; }
        public double? Svprec { get; set; }
        public double? Svven1 { get; set; }
        public double? Svven2 { get; set; }
        public double? Svcomb { get; set; }
        public string Svpr01 { get; set; }
        public string Svpr02 { get; set; }
        public string Svpr03 { get; set; }
        public string Svpr04 { get; set; }
        public string Svpr05 { get; set; }
    }
}
