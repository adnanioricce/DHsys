using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Client : BaseEntity
    {
        public int ClientId { get; set; }
        public int? Addressid { get; set; }
        public string ClientName { get; set; }
        public string Cpf { get; set; }

        public virtual Address Address { get; set; }
    }
}
