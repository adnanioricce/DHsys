using System;
using System.Linq;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class BeneficiaryDto : BaseEntityDto
    {
        public string Name { get; set; }

        public int AddressId { get; set; }

        public AddressDto Address { get; set; }
        
    }
}