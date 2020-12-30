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
        public string EanCode { get; set; }
        public string ProductName { get; set; }
        public string PresentationName { get; set; }
        public string Cas { get; set; }
        public string Substancia { get; set; }
        public short ProductType { get; set; }
        public string Lcct { get; set; }
        public bool ClinicRestrict { get; set; }
        public char Cap { get; set; }
        public char Confaz87 { get; set; }
        public decimal NumeroPF0Inteiro { get; set; }
        public decimal NumeroPF18Inteiro { get; set; }

    }
}
