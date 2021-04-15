using Core.Entities.Financial;
using System;
using System.Collections.Generic;

namespace Core.Entities.Inventory
{
    public class Manufacturer : Beneficiary
    {                        
        public string Cnpj { get; set; }        
        
    }
}
