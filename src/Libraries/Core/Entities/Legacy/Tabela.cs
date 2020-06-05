using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Tabela : BaseEntity
    {
        
        public string Abc { get; set; }
        public string Ctr { get; set; }
        public string Nom { get; set; }
        public string Des { get; set; }
        public double? Pla1 { get; set; }
        public double? Pco1 { get; set; }
        public double? Fra1 { get; set; }
        public double? Uni { get; set; }
        public double? Ipi { get; set; }
        public DateTime? Dtvig { get; set; }
        public string Neutro { get; set; }
        public string Negpos { get; set; }
        public string Custom { get; set; }
        public string MedDes { get; set; }
        public string MedApr { get; set; }
        public string MedPrinci { get; set; }
        public string MedRegims { get; set; }
        public string LabNom { get; set; }
        public double? Barra { get; set; }
    }
}
