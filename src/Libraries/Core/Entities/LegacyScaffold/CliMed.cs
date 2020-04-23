using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class CliMed
    {
        public int Id { get; set; }
        public string CpfCrm { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Sexo { get; set; }
        public string Fone { get; set; }
    }
}
