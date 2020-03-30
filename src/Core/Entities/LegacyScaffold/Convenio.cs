using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Convenio
    {
        public int Id { get; set; }
        public string Fucdem { get; set; }
        public string Fucodi { get; set; }
        public string Cvnota { get; set; }
        public string Cvbalc { get; set; }
        public DateTime? Cvdata { get; set; }
        public DateTime? Cvmesdesc { get; set; }
        public double? Cvvalourv { get; set; }
        public string Cvobsv { get; set; }
        public string Cvtick { get; set; }
        public string Cvreceita { get; set; }
        public string Cvrec { get; set; }
        public DateTime? Cvdtrec { get; set; }
        public string Cvpsuso { get; set; }
        public string Cventrega { get; set; }
        public double? Cvvalocrz { get; set; }
        public double? Cvcomissao { get; set; }
        public DateTime? Cvlibcom { get; set; }
        public string Cvfilial { get; set; }
        public string Cvtitular { get; set; }
    }
}
