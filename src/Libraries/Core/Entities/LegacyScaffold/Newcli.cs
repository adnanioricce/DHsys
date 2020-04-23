using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Newcli
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Fone { get; set; }
        public string Rg { get; set; }
        public DateTime? Datanasc { get; set; }
        public string Tipo { get; set; }
        public string Impresso { get; set; }
        public double? Desconto { get; set; }
        public string Clclassi { get; set; }
        public DateTime? UltCompra { get; set; }
    }
}
