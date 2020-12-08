using Core.Entities.Financial;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Client : Beneficiary
    {                        
        public string Cpf { get; set; }        
    }
}
