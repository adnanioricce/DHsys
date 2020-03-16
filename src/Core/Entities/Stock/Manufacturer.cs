using System;
using System.Collections.Generic;

namespace Core.Entities.Stock
{
    public partial class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public int? Addressid { get; set; }
        public string ManufacturerName { get; set; }
        public string Cnpj { get; set; }

        public virtual Address Address { get; set; }
    }
}
