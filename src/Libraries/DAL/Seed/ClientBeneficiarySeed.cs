using Core.Entities;
using System;

namespace DAL.Seed
{
    public class ClientBeneficiarySeed : IDataObjectSeed<Client>
    {
        public Client GetSeedObject()
        {
            
            var client = new Client
            {
                Address = new AddressSeed().GetSeedObject(),
                Cpf = "208.976.920-39",
                CreatedAt = DateTimeOffset.UtcNow,
                Name = "Client Name",
                UniqueCode = Guid.NewGuid().ToString()
            };
            return client;
        }
    }
}
