using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Movnf : BaseEntity
    {
        
        public string Prcodi { get; set; }
        public double? Prqtde { get; set; }
        public double? VlUnit { get; set; }
        public string Ticket { get; set; }
        public DateTime? Data { get; set; }
        public string Ecf { get; set; }
        public string Descricao { get; set; }
        public string Cancelado { get; set; }
        public string Cpf { get; set; }
        public double? VlTot { get; set; }
    }
}
