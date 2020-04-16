using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Nfe
    {
        public int Id { get; set; }
        public string Campo { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Qtde { get; set; }
        public string Valor { get; set; }
        public string Vltot { get; set; }
        public string Ncm { get; set; }
        public string Imp { get; set; }
        public string Icms { get; set; }
        public string Prcdimp { get; set; }
    }
}
