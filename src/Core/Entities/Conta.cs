using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Conta : BaseEntity
    {        
        public string NomeEmpresa { get; set; }
        public string DataDeVencimento { get; set; }
        public decimal Valor { get; set; }
    }
}
