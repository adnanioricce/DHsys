using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public class Cliente : BaseEntity
    {        
        public string Clcodi { get; set; }
        public string Clnome { get; set; }
        public string Clende { get; set; }
        public string Clestado { get; set; }
        public string Clcep { get; set; }
        public string Cltele { get; set; }
        public double? Cldebi { get; set; }
        public double? Clpagto { get; set; }
        public double? Cllime { get; set; }
        public DateTime? Clcompra { get; set; }
        public DateTime? Clupagto { get; set; }
        public string Clcida { get; set; }
        public string Cldesc { get; set; }
        public double? Cldesmed { get; set; }
        public double? Cldesper { get; set; }
        public string Clbairro { get; set; }
        public DateTime? Clnasc { get; set; }
        public string Clrg { get; set; }
        public string Clobs { get; set; }
        public string Clcpf { get; set; }
        public double? Clcred { get; set; }
    }
}
