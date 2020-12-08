using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Seed
{
    public class ManufacturerBeneficiarySeed : IDataObjectSeed<Manufacturer>
    {
        public Manufacturer GetSeedObject()
        {
            var manufacturer = new Manufacturer
            {
                Address = new AddressSeed().GetSeedObject(),
                CreatedAt = DateTimeOffset.UtcNow,
                Cnpj = "04.101.354/0001-83",
                Name = "Manufacturer Name",
                UniqueCode = Guid.NewGuid().ToString()
            };
            return manufacturer;
        }
    }
}
