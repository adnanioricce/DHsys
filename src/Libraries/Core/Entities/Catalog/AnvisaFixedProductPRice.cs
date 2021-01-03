using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Catalog
{
    public class AnvisaFixedProductPrice : BaseEntity
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string RegistryCode { get; set; }
        public string GGREMCode { get; set; }
        public string Ean1 { get; set; }
        public string Ean2 { get; set; }
        public string Ean3 { get; set; }
        public string ProductName { get; set; }
        public string PresentationName { get; set; }
        public string Cas { get; set; }
        public string Substance { get; set; }
        public short ProductType { get; set; }
        public string Lcct { get; set; }
        public bool ClinicRestrict { get; set; }
        public char Cap { get; set; }
        public char Confaz87 { get; set; }        
        public bool IsRegulated { get; set; }
        public decimal PFSemImpostos { get; set; }
        public decimal PF0 { get; set; }
        public decimal PF12 { get; set; }
        public decimal PF17 { get; set; }
        public decimal PF17Alc { get; set; }
        public decimal PF17_5 { get; set; }
        public decimal PF17_5Alc { get; set; }
        public decimal PF18 { get; set; }
        public decimal PF18_Alc { get; set; }
        public decimal PF20 { get; set; }
        public decimal PMC0 { get; set; }
        public decimal PMC12 { get; set; }
        public decimal PMC17 { get; set; }
        public decimal PMC17_Alc { get; set; }
        public decimal PMC17_5 { get; set; }
        public decimal PMC17_5_Alc { get; set; }
        public decimal PMC18 { get; set; }
        public decimal PMC18Alc { get; set; }
        public decimal PMC20 { get; set; }        

    }
}
