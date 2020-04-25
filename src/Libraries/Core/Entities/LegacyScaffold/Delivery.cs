using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public  class Delivery
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime? Datanasc { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Fone { get; set; }
        public string Balcon { get; set; }
        public DateTime? Dtcad { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Impresso { get; set; }
        public double? Acumulado { get; set; }
        public string Aposentado { get; set; }
        public double? Descmed { get; set; }
        public double? Descout { get; set; }
        public string Clclassi { get; set; }
        public string Clobs1 { get; set; }
        public string Clobs2 { get; set; }
        public DateTime? UltCompra { get; set; }
    }
}
